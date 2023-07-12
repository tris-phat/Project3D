using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount ==0)
        {
            DragAndDropItem dragitem = eventData.pointerDrag.GetComponent<DragAndDropItem>();
            dragitem.parrentAfter = transform;
            
        }
    }
}
