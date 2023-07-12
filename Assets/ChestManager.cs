using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip open;

    private Transform Player;
    public float Radius;
    public GameObject Button;
    private Animator anim;
    public Transform Point;
    public Slider slide;
    public GameObject[] item;

    public bool enemy;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        if(!enemy)
        {
            slide = Button.GetComponent<Slider>();
        }
        
    }
    private void Update()
    {
        if(!enemy)
        {
            var distance = Vector3.Distance(Player.position, transform.position);
            if (distance <= Radius)
            {
                Button.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    slide.value += Time.deltaTime;
                    if (slide.value >= 1)
                    {
                        anim.SetBool("Open", true);
                       

                    }


                }
                else
                {
                    if (slide.value < 1)
                    {
                        slide.value = 0;
                    }
                }
            }
            else Button.SetActive(false);
        }
        
    }
    public void LootItem()
    {


        for(int i =0; i< item.Length;i++)
        {
            
             Instantiate(item[i], Point.position, Point.rotation);
            
        }
    }
    [ContextMenu("Test")]
    public void LootItemEnemyDeath()
    {
        var rd = Random.Range(0, item.Length);
        Instantiate(item[rd], Point.position + new Vector3(0, 1, 0), Point.rotation);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    public void PlayMFXOpen()
    {
        audioSource.PlayOneShot(open);
    }
}
