using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    [SerializeField]
    private GameObject Inventory;


   public bool ispause = false;


    private void Start()
    {
        Inventory.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(GameManager.Instance.MapUI.activeInHierarchy)
            {
                GameManager.Instance.MapUI.SetActive(false);
                return;
            }


            if (!ispause)
            {
                ispause = true;
                GameManager.Instance.PauseGame();
                GameManager.Instance.mouseControl.UnClockMouse();
            }
            else
            {
                GameManager.Instance.ResumeGame();
                ispause = false;
            }
           
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            Inventory.SetActive(true);
            GameManager.Instance.mouseControl.UnClockMouse();
        }
        else
        {
            Inventory.SetActive(false);
            GameManager.Instance.mouseControl.ClockMouse();
        }

    }
}
