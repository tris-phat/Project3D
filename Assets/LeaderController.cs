using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class LeaderController : MonoBehaviour
{
    public Image WarningImage;
    public GameObject BoxTalk;
    public TMP_Text Description;
    public GameObject Camera;

    public float RadiusConnect;


    public bool Connect;
    public bool Done;

    private GameObject _player;

    public string[] Conversation;
    public int index;

    private void Awake()
    {
        WarningImage.enabled = true;
    }


    public  void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        BoxTalk.SetActive(false);
    }

    public  void Update()
    {
        var dir = Vector3.Distance(_player.transform.position, transform.position);

        if(!Connect)
        {
            if (dir <= RadiusConnect)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    WarningImage.enabled = false;
                    Connect = true;
                    Camera.SetActive(false);
                }
            }
        }
        else
        {
            if (!Done)
            {
                StartCoroutine(Talking());

              
            }
           
            
        }
       
    }

    public  IEnumerator Talking()
    {
        BoxTalk.SetActive(true);

        for(int i =0; i < Conversation.Length;i++)
        {
            Description.text = Conversation[i];
            yield return WaitAnyKey();
        }
        Camera.SetActive(true);
        BoxTalk.SetActive(false);
        Done = true;
        yield return null;

    }
    public  IEnumerator WaitAnyKey()
    {
        
        yield return new WaitUntil(() => Input.anyKeyDown);
    
    }
   
   

}
