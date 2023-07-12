using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;
    private AudioSource audioSource;
    public AudioClip MFXpickup;

    public bool gem;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player"))
        {
            return;
        }


        PickupDrop();
     

    }
    

    
    public void PickupShop()
    {
        
        InventoryManager.Instance.AddItemList(item);
        
    }
    private void PickupDrop()
    {
        InventoryManager.Instance.AddItemList(item);
        audioSource.PlayOneShot(MFXpickup);
        if(gem)
        {
            Win();
        }
        Destroy(gameObject);
    }


    public void Win()
    {
        GameManager.Instance.FadeAnim.SetActive(true);
        GameManager.Instance.MapController.TelePos(1);
    }
}
