using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : AttackManager
{
    public int WeaponID;
    public int Damage;

    public int CurrentHit;
    public int MaxHit;
    public GameObject effectSkillSpecial;
    public GameObject Camera;
    private Animator anim;
   
    private void Start()
    {
        CurrentHit = 0;
        anim = GetComponentInParent<Animator>();
    }
   
    public override void Attack()
    {

        CurrentHit++;
        if (CurrentHit > MaxHit)
        {
            CurrentHit = 0;
        }
    }
    public override void SpecialSkillSword()
    {
        anim.SetTrigger("SpecialSkillSword");
        
        //Camera.SetActive(true);
    }
    //public override void CinematicSpecialSkillWord()
    //{
    //    StartCoroutine(CinematicSkill());
    //}

    //IEnumerator CinematicSkill()
    //{
    //    var effect = Instantiate(effectSkillSpecial, this.transform.position, this.transform.rotation);
    //    Destroy(effect, 2);
    //    Time.timeScale = 0.5f;
    //    yield return new WaitForSeconds(1f);
    //    Time.timeScale = 1;
    //}

}
