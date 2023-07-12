using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour 
{
    [Header("Medicine")]
    public int HealthValue;
    public GameObject HealthEffect;
    public int ManaValue;
    public GameObject ManaEffect;

    public GameObject CharacterEquipment;
    public SetDataItem Item;
    public GameObject CameraBow;
    private GameObject player;
    private Animator anim;


  

    private void Start()
    {
        Item = GetComponent<SetDataItem>();
       
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponentInChildren<Animator>();
        CharacterEquipment = GameObject.FindGameObjectWithTag("CharacterEquipment");
       
    }
    private void Update()
    {
        CameraBow = GameObject.FindGameObjectWithTag("CameraBow");
    }
    [ContextMenu("use item")]
    public void UsedItem()
    {
        if(ItemType.HealthPotion == Item.item.itemType)
        {
            UseHealthPotion();

        }
        if (ItemType.ManaPotion == Item.item.itemType)
        {
            UseManaPotion();

        }
        if (ItemType.Sword == Item.item.itemType)
        {
            UseSword();
        }
        if (ItemType.Shield == Item.item.itemType)
        {
            UseShield();
        }
        if(ItemType.Bow == Item.item.itemType)
        {
            UseBow();
        }
        if(ItemType.Hammer == Item.item.itemType)
        {
            UseHammer();
        }
        if(ItemType.Bomb == Item.item.itemType)
        {
            UseBomb();
        }
        if(ItemType.Map == Item.item.itemType)
        {
            UseMap();
        }
    }
    private void UseHealthPotion()
    {

        if (Item.count > 0)
        {
            player.GetComponent<HealthPoint>().ResumeHealth(HealthValue);
            var effect = Instantiate(HealthEffect, player.transform.position, player.transform.rotation);
            Destroy(effect, 1f);
            Item.count--;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void UseManaPotion()
    {
        if (Item.count > 0)
        {
            player.GetComponent<ManaPoint>().ResumeMana(ManaValue);
            var effect = Instantiate(ManaEffect, player.transform.position, player.transform.rotation);
            Destroy(effect, 1f);
            Item.count--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UseSword()
    {

        var currentTranform = gameObject.transform.parent;
        var slotWeapon = CharacterEquipment.GetComponentInChildren<SlotWeapon>();
        var HandLeft = CharacterEquipment.GetComponentInChildren<SlotShield>();
        if(HandLeft.transform.childCount > 0)
        {
            var CheckItem = HandLeft.transform.GetChild(0).GetComponent<UseItem>();
            if(CheckItem.Item.item.itemType == ItemType.Bow)
            {
                var CurrentItemHandLeft = HandLeft.transform.GetChild(0);
                CurrentItemHandLeft.transform.SetParent(currentTranform);
            }
           
        }

        gameObject.transform.SetParent(slotWeapon.transform);
        

        if (slotWeapon.transform.childCount >= 2)
        {
        
            var item1 = slotWeapon.transform.GetChild(0);
            item1.transform.SetParent(currentTranform);

        }
        

    }
    public void UseShield()
    {

        var currentTranform = gameObject.transform.parent;
        var slotShiled = CharacterEquipment.GetComponentInChildren<SlotShield>();

        gameObject.transform.SetParent(slotShiled.transform);
        Debug.Log(slotShiled.transform.childCount);

        if (slotShiled.transform.childCount >= 2)
        {

            var itemchild1 = slotShiled.transform.GetChild(0);
            itemchild1.transform.SetParent(currentTranform);

        }

    }
    public void UseBow()
    {
        var currentTranform = gameObject.transform.parent;
        var slotShiled = CharacterEquipment.GetComponentInChildren<SlotShield>();
        var HandRight = CharacterEquipment.GetComponentInChildren<SlotWeapon>();

       
 
        if (HandRight.transform.childCount > 0 )
        {
           
           
            var toolbar = GameObject.FindGameObjectWithTag("ToolBar");
        
            GameObject[] slottoolbar = toolbar.GetComponent<ToolBarManager>().ToolBarSlots;
            for (int i = 0; i < slottoolbar.Length; i++)
            {
               

                if (slottoolbar[i].transform.childCount == 0)
                {

                    var CurrentItemHandRight = HandRight.transform.GetChild(0);
                    CurrentItemHandRight.transform.SetParent(slottoolbar[i].transform);
                }
            }
           if(slotShiled.transform.childCount >= 1)
           {
                var itemchild1 = slotShiled.transform.GetChild(0);
                itemchild1.transform.SetParent(currentTranform);
                gameObject.transform.SetParent(slotShiled.transform);
           }
           else
           {
                gameObject.transform.SetParent(slotShiled.transform);
           }



        }
        else 
        {
            if (slotShiled.transform.childCount >= 1)
            {


                var itemchild1 = slotShiled.transform.GetChild(0);
                itemchild1.transform.SetParent(currentTranform);
                gameObject.transform.SetParent(slotShiled.transform);

            }
            else
            {
                gameObject.transform.SetParent(slotShiled.transform);
            }

        }

        if (slotShiled.transform.childCount == 0)
        {
            gameObject.transform.SetParent(slotShiled.transform);
        }




    }
    public void UseHammer()
    {
        var currentTranform = gameObject.transform.parent;
        var slotWeapon = CharacterEquipment.GetComponentInChildren<SlotWeapon>();

        gameObject.transform.SetParent(slotWeapon.transform);
        Debug.Log(slotWeapon.transform.childCount);

        if (slotWeapon.transform.childCount >= 2)
        {

            var item1 = slotWeapon.transform.GetChild(0);
            item1.transform.SetParent(currentTranform);

        }
    }

    public void UseBomb()
    {

        if (CameraBow.activeInHierarchy)
        {
            if (Item.count > 0)
            {
                var arrow = player.GetComponentInChildren<AttackBow>().Firearrow = true;


                Item.count--;
                if(Item.count <=0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else return;
        
    }
    public void UseMap()
    {
        GameManager.Instance.MapUI.SetActive(true);
        GameManager.Instance.mouseControl.UnClockMouse();
    }
}
