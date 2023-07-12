 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour ,
    
    IEndDragHandler, IDragHandler , IBeginDragHandler
    
{
    private Image image;
    public Transform  parrentAfter;
    public CanvasGroup Alpha;
    
    private void Start()
    {

        image = GetComponent<Image>();
        parrentAfter = GetComponentInParent<Transform>();

    }
    // kéo item
    public void OnDrag(PointerEventData eventData)
    {
       
        transform.position = Input.mousePosition;
        transform.SetParent(transform.root);
    }
    // bắt đầu kéo
    public void OnBeginDrag(PointerEventData eventData)
    {
        Alpha.alpha = 0.5f;
        
        image.raycastTarget = false;
     
    }
    // kết thúc kéo
    public void OnEndDrag(PointerEventData eventData)
    {
        Alpha.alpha = 1f;

       
        image.raycastTarget = true;
        transform.SetParent(parrentAfter);
       
    }
   

}
