using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private GameObject SlotWeapon;
    [SerializeField]
    private GameObject SlotShield;

    public bool open;

    private void Start()
    {
       CloseInventory();
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Tab))
        {
            if(!open)
            {
                OpenInventory();
                Time.timeScale = 0;
            }
            
            
        }
        else
        {
            CloseInventory();
            Time.timeScale = 1;
            MouseControl.Instance.ClockMouse();
        }

    }
    public void OpenInventory()
    {
        open = true;
        Inventory.SetActive(true);
        //OpenCharacterEquip(true);
       
        MouseControl.Instance.UnClockMouse();
    }
    public void OpenCharacterEquip(bool open)
    {
        SlotWeapon.GetComponent<Image>().enabled = open;

        if (SlotWeapon.transform.childCount != 0)
        {
            Image[] imageWeapon = SlotWeapon.GetComponentsInChildren<Image>();
            for (int i = 0; i < imageWeapon.Length; i++)
            {
                imageWeapon[i].enabled = open;
            }

        }

        SlotShield.GetComponent<Image>().enabled = open;
        if (SlotShield.transform.childCount != 0)
        {
            Image[] imageShield = SlotShield.GetComponentsInChildren<Image>();
            for (int i = 0; i < imageShield.Length; i++)
            {
                imageShield[i].enabled = open;
            }

        }
    }

    public void CloseInventory()
    {
        open = false;
        Inventory.SetActive(false);
        //OpenCharacterEquip(open);
       

    }


}
