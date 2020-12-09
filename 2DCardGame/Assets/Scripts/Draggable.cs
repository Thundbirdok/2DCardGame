using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform hand;
    private Transform canvas;

    private GameObject placeholder;
    private Transform fieldToDropPlaceholder = null;

    private CanvasGroup canvasGroup;

    private bool isDraggable = true;

    // Start is called before the first frame update
    void Start()
    {

        hand = transform.parent;
        canvas = transform.parent.parent;

        canvasGroup = GetComponent<CanvasGroup>();

        placeholder = canvas.Find("Placeholder").gameObject;

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

            if (fieldToDropPlaceholder == null)
            {

                return;

            }

            if (placeholder.transform.parent != fieldToDropPlaceholder)
            {

                placeholder.transform.SetParent(fieldToDropPlaceholder);

            }

            int newSiblingIndex = fieldToDropPlaceholder.childCount;

            for (int i = 0; i < fieldToDropPlaceholder.childCount; ++i)
            {

                if (transform.position.x < fieldToDropPlaceholder.GetChild(i).position.x)
                {

                    newSiblingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    {

                        --newSiblingIndex;

                    }

                    break;

                }

            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);

        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        if (isDraggable)
        {

            transform.SetParent(canvas);
            canvasGroup.blocksRaycasts = false;

            AddPlaceholder(hand);
            
            //Add array of valid drop zones to hightlight them

        }

    }

    //Activates after OnDrop in DropZone
    public void OnEndDrag(PointerEventData eventData)
    {

        if (transform.parent == canvas)
        {

            PutInHand();

        }

        canvasGroup.blocksRaycasts = true;

    }

    public void PutOnField(Transform field)
    {

        isDraggable = false;

        transform.SetParent(field);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        placeholder.transform.SetParent(canvas);
        placeholder.SetActive(false);

    }

    public void PutInHand()
    {

        transform.SetParent(hand);
        
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        placeholder.transform.SetParent(canvas);
        placeholder.SetActive(false);

    }

    public void AddPlaceholder(Transform field)
    {

        fieldToDropPlaceholder = field;
        placeholder.SetActive(true);

    }

    public void RemovePlaceholder()
    {

        fieldToDropPlaceholder = null;
        placeholder.transform.SetParent(canvas);
        placeholder.SetActive(false);

    }

}
