using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
   
    public static InventoryManager Instance;

   
    public GameObject ItemPrefab;
    public DropItemSlot[] Slots;
    public DropItemSlot[] SlotToolBar;

    public Item[] items;

    private void Awake()
    {
        Instance = this;
   
    }
    private void Start()
    {
        for(int i =0; i < items.Length;i++)
        {
            AddItemList(items[i]);
        }

    }


    public void AddItemList(Item newitem)
    {
        print("add");
        //check item, if newitem is StackAble == true and newitem == item had item count++
        for (int i = 0; i < Slots.Length; i++)
        {
            DropItemSlot slot = Slots[i];
            SetDataItem item = slot.GetComponentInChildren<SetDataItem>();

            if (item != null)

            {
                if (item.item.StackAble == true)
                {
                    if (item.item == newitem)
                    {


                        if (item.item.itemType == ItemType.Bomb)
                        {
                            var rb = Random.Range(0, 2);
                            item.count += rb;

                        }
                        else
                        {
                            item.count++;

                        }
                        item.RefreshCount();
                        return;
                    }


                }


            }

        }
        for(int i =0; i < SlotToolBar.Length;i++)
        {
            var slot = SlotToolBar[i];
            var item = slot.GetComponentInChildren<SetDataItem>();
            if(item !=null)
            {
                if(item.item.StackAble== true)
                {
                    if (item.item.itemType == ItemType.Bomb)
                    {
                        var rd = Random.Range(0, 5);
                        item.count += rd;
                        item.RefreshCount();
                        

                    }
                    
                    
                }
            }
        }


        for (int i = 0; i < Slots.Length; i++)
        {
            DropItemSlot slot = Slots[i];
            SetDataItem item = slot.GetComponentInChildren<SetDataItem>();

            if (item == null)
            {
                
                DisPlayItemInventory(newitem, slot);
               
                 return;

            }

        }



    }


    private void DisPlayItemInventory(Item item, DropItemSlot slot)
    {

        var newitem = Instantiate(ItemPrefab, slot.transform);
        SetDataItem i = newitem.GetComponent<SetDataItem>();
        i.SetData(item);
        
        
        
    }
   
   
}
