using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBow : MonoBehaviour
{
    public static event Action<int> ActiveBowEvent;
    [SerializeField]
    private Bow[] bows;
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private GameObject CrossHair;
    private bool _bow;
    public bool Bow
    {
        get => _bow;
        set
        {
            _bow = value;
            AnimIdleBow();
            //ActiveCrossHair();
        }
    }
    private void Start()
    {
        Animator = GetComponentInParent<Animator>();
    }
    public void ActiveCrossHair()
    {
        CrossHair.SetActive(Bow);
    }
    public void AnimIdleBow()
    {
        Animator.SetBool("IdleBow", Bow);
    }
    public static void ActiveBow(int ID)
    {
        ActiveBowEvent?.Invoke(ID);
    }


    private void OnEnable()
    {
        ActiveBowEvent += Active;
    }
    private void Active(int Idtem)
    {

        for (int i = 0; i < bows.Length; i++)
        {
            if (Idtem == bows[i].BowID)
            {
                bows[i].gameObject.SetActive(true);
                if (!GameManager.Instance.Die)
                {
                    Bow = true;
                }
                else Bow = false;
            }
            else
            {
                bows[i].gameObject.SetActive(false);
            }
        }
        if (Idtem == 0)
        {
            for (int i = 0; i < bows.Length; i++)
            {
                bows[i].gameObject.SetActive(false);
                Bow = false;
            }
        }
    }

}
