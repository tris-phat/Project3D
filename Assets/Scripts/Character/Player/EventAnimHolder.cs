using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAnimHolder : MonoBehaviour
{
    public CharacterJump characterJump;
    public AttackSword attacksword;
    public AttackBow attackBow;
    
    public ChangeStatusVFX[] changeStatusVFX;
    public RoundFire RoundFire;
    public PlayEffectSkill Effectroundfire;
    public PlayEffectSkill EffectslashBlack;
    public PlayEffectSkill EffectlighHealth;

    public GameObject smokeRollonGround;
    public GameObject smokeRollinAir;

    public void SmokeRoll()
    {
        if(!characterJump.Jumping)
        {
            var smkroll = Instantiate(smokeRollonGround, transform.position, transform.rotation);
            Destroy(smkroll, 1f);
        }
        else
        {
            var smkroll = Instantiate(smokeRollinAir, transform.position, transform.rotation);
            Destroy(smkroll, 1f);
        }
        
        
    }

    // call metod form Script AttackSword
    public void DamageAttackNormal() => attacksword.HurtEnemyAttackNormal();


    public void EffectSWordHit1()
    {
        attacksword.SLashAirHit1();
    }
    public void PlayMFXAttackSword()
    {
        attacksword.PlayMFXFlash();
    }

    public void TurnOnTrail()
    {

        for (int i = 0; i < changeStatusVFX.Length; i++)
        {
            changeStatusVFX[i].TurnOnVFX();

        }

    }
    public void TurnOffTrail()
    {

        for (int i = 0; i < changeStatusVFX.Length; i++)
        {
            changeStatusVFX[i].TurnOffVFX();

        }

    }
    public void EffectSpecialSkill()
    {
        attacksword.SpecialSkillSword();
    }
    public void TurnOffLaser()
    {
        attacksword.TurnOffLaserEffect();
    }
    public void DamageAttackSkillGroundFire() => RoundFire.HurtEnemyAttackSkill();
    public void EffectRoundFire() => Effectroundfire.PlayEffect();
    public void EffectSlashBlack() => EffectslashBlack.PlayEffect();
    public void EffectLightHealth() => EffectlighHealth.PlayEffect();

    public void Fire()
    {
        attackBow.Shoot();
    }
    public void PlayMFXAttackBow()
    {
        attackBow.PlayMFX();
    }
    public void PlayMFXWaitShoot()
    {
        attackBow.PlayMFXWaitShoot();
    }
   
    public void PlayMFXShootBow()
    {
        attackBow.PlayerMFXShoot();
    }

    public void InstantatieArrowBB()
    {
        attackBow.ArrowBB();
    }
    public void EndArrowFire()
    {
        attackBow.EndFireArrow();
    }
    
}
