using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hammer : AttackManager
{
    public int ID;

    public Animator anim;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    public override void Attack()
    {
        anim.SetTrigger("Loggingwood");
    }
}
