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

    [SerializeField]
    private coordinateDirections scrollDirection = coordinateDirections.X;

    private float difference;
    private Vector2 differenceXY;
    private Vector3 panelPosition;

    private void Start()
    {
        panelPosition = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        switch (scrollDirection)
        {
            case coordinateDirections.X:
                {
                    difference = data.pressPosition.x - data.position.x;
                    transform.position = panelPosition - new Vector3(difference, 0, 0);
                    break;
                }
            case coordinateDirections.Y:
                {
                    difference = data.pressPosition.y - data.position.y;
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
        panelPosition = transform.position;

        difference = 0f;            //probably not necessary, but here just in case
        differenceXY = Vector2.zero;
    }
}
