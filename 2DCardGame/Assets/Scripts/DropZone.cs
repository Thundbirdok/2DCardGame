using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {

        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if (draggable == null)
        {

            return;            

        }

        if (transform.tag == "Hand")
        {

            draggable.PutInHand(transform);

            return;

        }

        draggable.PutOnField(transform);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

}
