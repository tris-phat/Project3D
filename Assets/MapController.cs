using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapController : MonoBehaviour
{
    public List<GameObject> Points = new List<GameObject>();


 
    public void TelePos(int ID)
    {
        print("Chay");
        GameManager.Instance.FadeAnim.SetActive(true);
        GameManager.Instance.PlayerManager.GetComponent<CharacterController>().enabled = false;
        GameManager.Instance.PlayerManager.transform.position = Points[ID].transform.position;
        GameManager.Instance.PlayerManager.GetComponent<CharacterController>().enabled = true;

        print(Points[ID].transform.position);
       
    }
}
