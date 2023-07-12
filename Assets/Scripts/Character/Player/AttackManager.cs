using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class AttackManager : MonoBehaviour
{
    [Header("AudioClip")]
    public AudioSource AudioSource;

   
   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SpecialSkillSword();
            SpeacialSkillBow();
        }
       


        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if(Input.GetButton("Fire2"))
        {
            Defend();
            Aming();
        }
        else
        {
            UnDefend();
        }
        
    }
    public virtual void Attack()
    {

    }
    public virtual void Defend()
    {

    }
    public virtual void UnDefend()
    {

    }
    public virtual void Aming()
    {
        
    }
    public virtual void SpecialSkillSword()
    {
       

    }
    public virtual void SpeacialSkillBow()
    {
        
    }
   
}
