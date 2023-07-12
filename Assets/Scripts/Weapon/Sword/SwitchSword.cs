using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SwitchSword : MonoBehaviour
{
    public static event Action<int> ActiveSwordEvent;
    public Sword[] swords;


    [SerializeField]
    private Animator Animator;


    public bool _sword;
    public bool Sword
    {
        get => _sword;
        set
        {
            _sword = value;
            AnimIdleSword();
        }
    }

    private void Start()
    {
        Animator = GetComponentInParent<Animator>();
       
    }
    private void AnimIdleSword()
    {
        Animator.SetBool("IdleSword", Sword);
    }




    public static void ActiveSword(int ID)
    {
        ActiveSwordEvent?.Invoke(ID);
    }


    private void OnEnable()
    {
        ActiveSwordEvent += Active;
    }
    private void Active(int Idtem)
    {

        for(int i =0;i< swords.Length;i++)
        {
            if(Idtem == swords[i].WeaponID)
            {
                swords[i].gameObject.SetActive(true);
                if (!GameManager.Instance.Die)
                {
                    Sword = true;
                }
                else Sword = false;
            }
                
            else
            {
                swords[i].gameObject.SetActive(false);
            }
        }
        if(Idtem ==0)
        {
            for(int i =0;i<swords.Length;i++)
            {
                swords[i].gameObject.SetActive(false);
                Sword = false;
            }
        }
    }
    
}
