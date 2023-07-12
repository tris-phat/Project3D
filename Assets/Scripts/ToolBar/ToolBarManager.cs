using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarManager : MonoBehaviour
{
    public UseItem[] item;
    public GameObject[] ToolBarSlots;
    public int CurrentIndex;

    private void Update()
    {
        for(int i =0; i < ToolBarSlots.Length;i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 +i))
            {
                CurrentIndex=i;
                UseIteminSlot();
            }
            
        }
    }
    private void UseIteminSlot()
    {
        
            UseItem item = ToolBarSlots[CurrentIndex].GetComponentInChildren<UseItem>();
            if(item !=null)
            {
                item.UsedItem();
            }
        
    }
}
