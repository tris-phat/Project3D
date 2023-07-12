using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHammer : MonoBehaviour
{
    public static event Action<int> ActiveHammerEvent;

    public Hammer[] hammers;

    public Animator anim;

   
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public static void ActiveHammer(int ID)
    {
        ActiveHammerEvent?.Invoke(ID);
    }

   


    private void OnEnable()
    {
        ActiveHammerEvent += Active;
    }

    private void Active(int Idtem)
    {

        for (int i = 0; i < hammers.Length; i++)
        {
            if (Idtem == hammers[i].ID)
            {
                hammers[i].gameObject.SetActive(true);
               
            }
            else
            {
                hammers[i].gameObject.SetActive(false);
                
            }
        }
        if (Idtem == 0)
        {
            for (int i = 0; i < hammers.Length; i++)
            {
                hammers[i].gameObject.SetActive(false);
               
            }
        }
    }
}
