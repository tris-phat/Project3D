using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchShield : MonoBehaviour
{
    public static event Action<int> ActiveShieldEvent;
    public Shield[] shields;


    [SerializeField]
    private Animator Animator;


    public bool _shield;
    public bool Shield
    {
        get => _shield;
        set
        {
            _shield = value;
            AnimIdleShiel();
        }
    }

    private void Start()
    {
        Animator = GetComponentInParent<Animator>();

    }
    private void AnimIdleShiel()
    {
        Animator.SetBool("IdleShield", Shield );
    }




    public static void ActiveShield(int ID)
    {
        ActiveShieldEvent?.Invoke(ID);
    }


    private void OnEnable()
    {
        ActiveShieldEvent += Active;
    }
    private void Active(int Idtem)
    {

        for (int i = 0; i < shields.Length; i++)
        {
            if (Idtem == shields[i].ShieldID)
            {
                shields[i].gameObject.SetActive(true);
                if (!GameManager.Instance.Die)
                {
                    Shield = true;
                }
                else Shield = false;
                
            }
            else
            {
                shields[i].gameObject.SetActive(false);
            }
        }
        if (Idtem == 0)
        {
            for (int i = 0; i < shields.Length; i++)
            {
                shields[i].gameObject.SetActive(false);
                Shield = false;
            }
        }
    }
}
