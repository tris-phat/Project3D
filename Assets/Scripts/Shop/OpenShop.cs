using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OpenShop : MonoBehaviour
{
    [SerializeField]
    private GameObject Button;
    [SerializeField]
    private GameObject Shop;
  

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private float Radius;

    [SerializeField]
    private bool Open;
    public UnityEvent OpenInventory;
    public UnityEvent CloseInventory;
    private void Start()
    {
        ActiveButton(false);
        CloseShop();
    }
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, Player.position);
        if(distance <= Radius)
        {
            if(!Open)
            {
                ActiveButton(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenInventory.Invoke();
                    Openshop();
                    ActiveButton(false);

                }
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                CloseShop();
                CloseInventory.Invoke();
            }
           
            
        }
        else
        {
            ActiveButton(false);
           
        }
    }



    private void ActiveButton(bool active) => Button.SetActive(active);

    private void Openshop()
    {
        Open = true;
        Shop.SetActive(true);

        MouseControl.Instance.UnClockMouse();
    }
    private void CloseShop()
    {
        Open = false;
        Shop.SetActive(false);

        MouseControl.Instance.ClockMouse();
    }

   


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
