using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetDataItem : MonoBehaviour
{
    
    public Item item;
    public Image image;

    public TMP_Text CountItem;
    public int count = 1;

    
    public void SetData(Item Data)
    {
        
        item = Data;
        image.sprite = Data.Image;
        
    }
    public void RefreshCount()
    {
        CountItem.text = count.ToString();
        bool TextActive = count > 0;
        CountItem.gameObject.SetActive(TextActive);
    }

   
   
    
    
   
}
