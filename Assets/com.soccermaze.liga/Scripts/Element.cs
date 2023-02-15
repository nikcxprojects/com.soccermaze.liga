using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
    }
}
