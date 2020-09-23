//MapScroll.cs by Mikko Kyllönen
//Handles how the player interacts with the map screen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapScroll : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private enum coordinateDirections
    {
        X,
        Y,
        XY
    };

    [SerializeField] private coordinateDirections scrollDirection = coordinateDirections.X; //is overridden, but is here just to get rid of warning messages in the debug log
    [SerializeField] private GameObject mapScreen;
    private RectTransform mapScreenRect;

    private float difference;
    private Vector2 differenceXY;
    private Vector3 panelPosition;
    [SerializeField] private Vector3 endPosition;

    public struct MapScreenInfo
    {
        public float bottom;
        public float top;
    }

    private MapScreenInfo mapScreenInfo;

    [Header("Additional Values")]
    [Tooltip("If you want the player's scrolling to stop earlier than the map texture's edge, increase this value.")]
    [SerializeField] private uint horizontalOffset = 0;
    [Tooltip("If you want the player's scrolling to stop earlier than the map texture's edge, increase this value.")]
    [SerializeField] private uint verticalOffset = 0;
    [SerializeField] private float bounceBackDuration = 0;

    private void Start()
    {
        panelPosition = transform.position;
        mapScreenRect = mapScreen.GetComponent<RectTransform>();

        mapScreenInfo.bottom = mapScreenRect.rect.position.y;
        mapScreenInfo.top = (mapScreenRect.rect.height - Screen.height) * -1;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        StopCoroutine(DampScrolling(transform.position));
    }

    public void OnDrag(PointerEventData data)
    {
        switch (scrollDirection)
        {
            case coordinateDirections.X:
                {
                    //this is left unfinished for now, as the map screen will likely be on the Y-axis.
                    difference = data.pressPosition.x - data.position.x;
                    endPosition = panelPosition - new Vector3(difference, 0, 0);
                    transform.position = panelPosition - new Vector3(difference, 0, 0);
                    break;
                }
            case coordinateDirections.Y:
                {
                    difference = data.pressPosition.y - data.position.y;

                    //this whole block handles the map screen's edge borders.
                    if (transform.position.y > mapScreenInfo.bottom - verticalOffset)
                    {
                        endPosition = new Vector3(transform.position.x, mapScreenInfo.bottom - verticalOffset, 0);
                    }
                    else if (transform.position.y < mapScreenInfo.top + verticalOffset)
                    {
                        endPosition = new Vector3(transform.position.x, mapScreenInfo.top + verticalOffset, 0);
                    }
                    else
                    {
                        endPosition = panelPosition - new Vector3(0, difference, 0);
                    }

                    transform.position = panelPosition - new Vector3(0, difference, 0);
                    break;
                }
            case coordinateDirections.XY:
                {
                    differenceXY = data.pressPosition - data.position;
                    transform.position = panelPosition - new Vector3(differenceXY.x, differenceXY.y, 0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        panelPosition = transform.position;

        if (transform.position != endPosition)
        {
            StartCoroutine(DampScrolling(transform.position));
        }

        difference = 0f;            //probably not necessary, but here just in case
        differenceXY = Vector2.zero;
    }

    //Smoothly moves the map's position back to the edges of the camera.
    private IEnumerator DampScrolling(Vector3 playerPosition)
    {
        Vector3 velocity = new Vector3(1, 1, 1);

        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / bounceBackDuration;
            transform.position = Vector3.Lerp(playerPosition, endPosition, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
        panelPosition = transform.position;
    }
}
