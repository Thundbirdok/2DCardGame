using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform hand;
    Transform canvas;

    CanvasGroup canvasGroup;

    private bool isDraggable = true;

    // Start is called before the first frame update
    void Start()
    {

        hand = transform.parent;
        canvas = transform.parent.parent;

        canvasGroup = GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (isDraggable)
        {

            transform.position = eventData.position;

        }

    }    

    public void OnBeginDrag(PointerEventData eventData)
    {

        if (isDraggable)
        {

            transform.SetParent(canvas);
            canvasGroup.blocksRaycasts = false;

            //Add array of valid drop zones to hightlight them

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (isDraggable)
        {

            transform.SetParent(hand);
            canvasGroup.blocksRaycasts = true;

        }

    }

    public void PutOnField(Transform parent)
    {

        isDraggable = false;
        transform.SetParent(parent);

    }

    public void PutInHand(Transform parent)
    {

        transform.SetParent(parent);

    }

}
