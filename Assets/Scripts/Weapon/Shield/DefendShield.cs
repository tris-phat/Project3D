using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendShield : MonoBehaviour
{
    
    public bool Defend;
    [SerializeField]
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        var shield = GetComponentInChildren<Shield>();
        if(shield !=null)
        {
            Defend = shield.defend;
            AnimDefend(Defend);
        }
        
    }
    private void AnimDefend(bool defend)
    {
        Anim.SetBool("Defend", defend);
    }
    
}
