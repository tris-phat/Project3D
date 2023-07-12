using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockMagicManager : MonoBehaviour
{
    public float Radius;
    public GameObject light;
    public GameObject GemGreen;
   
    public GameObject Button;
    public Slider slide;
    
    private GameObject _player;

    private bool effect;

    public GameObject gem;

    public GameObject Camera;
   
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        var distance = Vector3.Distance(_player.transform.position, transform.position);


        if(distance <= Radius)
        {
            Button.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                slide.value += Time.deltaTime;
                if (slide.value == 1)
                {
                    
                    DropItemSlot[] inventory = InventoryManager.Instance.Slots;
                    for(int i =0; i < inventory.Length;i++)
                    {
                        var gem = inventory[i].gameObject.transform.GetChild(0).GetComponent<SetDataItem>();
                        if (gem.item.itemType == ItemType.RockMagic)
                        {
                            if(gem.item.gemType == GemMagicType.Green)
                            {
                                
                                light.SetActive(true);
                                effect = true;
                                     
                                
                            }
                           
                        }
                        
                    }
                    slide.value = 0;

                }
                

            }
            else
            {
                slide.value = 0;

            }
        }
        else
        {
            Button.SetActive(false);
        }


        if(effect == true)
        {
            
            Camera.SetActive(true);
            GameManager.Instance.PlayerManager.SetActive(false);
            var pointlight = light.GetComponent<Light>();
            pointlight.color = Color.green;
            if (pointlight.range <= 50)
            {
                pointlight.range += 10 * Time.deltaTime;
            }
            else
            {
                GemGreen.SetActive(true);
                pointlight.range = 1;
                light.SetActive(false);

            }
            if (light.transform.position.z <= 0.1f)
            {
                light.transform.position += new Vector3(0, 0, 0.01f);
            }
            StartCoroutine(end());

           

        }
       

    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(5);
        GameManager.Instance.WinScene.SetActive(true);

    }
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

}
