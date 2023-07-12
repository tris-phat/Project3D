using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MouseWandering : MonoBehaviour
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

    public Item[] Items;
    private bool gave;

    public GameObject gift;
    public Image image;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        BoxTalk.SetActive(false);
        WarningImage.enabled = true;
    }

    public void Update()
    {
        var dir = Vector3.Distance(_player.transform.position, transform.position);

        if (!Connect)
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
            else
            {
                if(!gave)
                {
                    Gift();
                }
                
               
            }

        }

    }

    public IEnumerator Talking()
    {
        BoxTalk.SetActive(true);

        for (int i = 0; i < Conversation.Length; i++)
        {
            Description.text = Conversation[i];
            yield return WaitAnyKey();
        }
        Camera.SetActive(true);
        BoxTalk.SetActive(false);
        Done = true;
        yield return null;

    }
    public IEnumerator WaitAnyKey()
    {

        yield return new WaitUntil(() => Input.anyKeyDown);

    }
    public void Gift()
    {
        for (int i = 0; i < Items.Length;i++)
        {
            InventoryManager.Instance.AddItemList(Items[i]);

            StartCoroutine(DisplayGift(Items[i]));
        }
        gave = true;

    }
    IEnumerator DisplayGift(Item item)
    {
        gift.SetActive(true);
        image.sprite = item.Image;
        image.transform.DOScale(5, 1f);
        yield return new WaitForSeconds(1);
        gift.SetActive(false);
        

    }

}
