using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapScroll : MonoBehaviour, IDragHandler, IEndDragHandler
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
    private Vector3 endPosition;

    private void Start()
    {
        panelPosition = transform.position;
        mapScreenRect = mapScreen.GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData data)
    {
        switch (scrollDirection)
        {
            case coordinateDirections.X:
                {
                    difference = data.pressPosition.x - data.position.x;
                    endPosition = panelPosition - new Vector3(difference, 0, 0);
                    transform.position = panelPosition - new Vector3(difference, 0, 0);
                    break;
                }
            case coordinateDirections.Y:
                {
                    difference = data.pressPosition.y - data.position.y;

                    if (transform.position.y > 0)
                    {
                        endPosition = new Vector3(transform.position.x, 0, 0);
                    }
                    else if (transform.position.y < (mapScreenRect.rect.height - Screen.height) * -1)
                    {
                        endPosition = new Vector3(transform.position.x, (mapScreenRect.rect.height - Screen.height) * -1, 0);
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
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        transform.position = endPosition;
        panelPosition = transform.position;

        endPosition = Vector3.zero;
        difference = 0f;            //probably not necessary, but here just in case
        differenceXY = Vector2.zero;
    }
}
