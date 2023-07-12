using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.Progress;

public class SlotWeapon : MonoBehaviour,IDropHandler
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
               if(item.item.itemType == ItemType.Sword)
               {
                    SwitchSword.ActiveSword(Id);

               }
                else if (item.item.itemType == ItemType.Hammer)
                {
                    SwitchSword.ActiveSword(0);
                }


                if (item.item.itemType == ItemType.Hammer)
                {
                    SwitchHammer.ActiveHammer(Id);
                }
                else if (item.item.itemType == ItemType.Sword)
                {
                    SwitchHammer.ActiveHammer(0);
                }

            }
        }
        else
        {
            SwitchSword.ActiveSword(0);
            SwitchHammer.ActiveHammer(0);
        }
    }

}
