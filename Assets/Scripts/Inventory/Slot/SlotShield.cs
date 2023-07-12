using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotShield : MonoBehaviour,IDropHandler
{
    public int Id;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            DragAndDropItem dragitem = eventData.pointerDrag.GetComponent<DragAndDropItem>();
            dragitem.parrentAfter = transform;
            UpdateUI();
        }


    }

    private void Update()
    {
        UpdateUI();

    }
    public void UpdateUI()
    {
        if (gameObject.transform.childCount != 0)
        {
            SetDataItem item = GetComponentInChildren<SetDataItem>();
            Id = item.item.Id;
            if (item != null )
            {
                if(item.item.itemType == ItemType.Shield)
                {
                    SwitchShield.ActiveShield(Id);
                }
                else if (item.item.itemType == ItemType.Bow)
                {
                    SwitchShield.ActiveShield(0);
                }


                if (item.item.itemType == ItemType.Bow)
                {
                    SwitchBow.ActiveBow(Id);
                }
                else if (item.item.itemType == ItemType.Shield)
                {
                    SwitchBow.ActiveBow(0);
                }
            }
            
        }
        else
        {
            SwitchShield.ActiveShield(0);
            SwitchBow.ActiveBow(0);
        }
    }

}
