using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackSword : MonoBehaviour
{
    [Header("MFX")]
    public AudioSource audioSource;
    public AudioClip MFXSwordAir;


    [SerializeField]
    private Animator Anim;

   
    public GameObject Bigbang;

    public Transform AttackPoint;
    public float PointRadius;
    [Header("Special Skill")]
    public GameObject LaserEffect;
    public GameObject effectSkillSpecial;
    public GameObject EffectUnderFoot;
    
    public float timescale;
    public float valueScale;
    public bool isScale;
    public GameObject CameraSkill;

    public int Damage;
    public int Hit;
    public GameObject HitEffect;
    
    public ParticleSystem hit1;
    public ParticleSystem hit2;
    public ParticleSystem hit3;


    

    private void Start()
    {
        Anim = GetComponentInParent<Animator>();
        Hit = 0;
    }
    private void Update()
    {
        var sword = GetComponentInChildren<Sword>();
        if(!GameManager.Instance.Die)
        {
            if (sword != null)
            {
                Hit = sword.CurrentHit;
                Damage = sword.Damage;
                CheckAttackPhase(Hit);
            }
            else
            {
                ResetAttackPhase();
            }
        }
       

        if(isScale)
        {
            if(timescale <=0.1)
            {
                timescale += Time.deltaTime;
            }
            else
            {
                timescale = 0;
                Time.timeScale = 1;
                isScale = false;
                CameraSkill.SetActive(false);
            }
        }
       
    }
   


    public void CheckAttackPhase(int hit)
    {
        if (hit == 0)
        {
            Anim.SetInteger("intHitPhase", 1);
            
        }

        if (Anim.GetCurrentAnimatorStateInfo(1).IsName("Hit1"))
        {

            if (hit > 1)
            {
                Anim.SetInteger("intHitPhase", 2);
                hit2.Emit(1);
               
            }
            

        }
        if (Anim.GetCurrentAnimatorStateInfo(1).IsName("Hit2"))
        {

            if (hit > 2)
            {
                Anim.SetInteger("intHitPhase", 3);
                hit3.Emit(1);
                
            }
            
        }
        if (Anim.GetCurrentAnimatorStateInfo(1).IsName("Hit3"))
        {

            if (hit > 3)
            {
                Anim.SetInteger("intHitPhase", 0);
            }

        }

       

    }

   

    public void ResetAttackPhase()
    {
        Hit = 0;
        Anim.SetInteger("intHitPhase", Hit);
    }

    public void HurtEnemyAttackNormal()
    {
        Collider[] Hit = Physics.OverlapSphere(AttackPoint.position, PointRadius);
        foreach (var hit in Hit)
        {
            if(hit.gameObject.CompareTag("Enemy"))
            {
                var HP = hit.GetComponent<ControlLifeEnemy>();
                if(HP)
                {
                    HP.TakeDamage(Damage);
                    var hiteffect = Instantiate(HitEffect, hit.transform.position, hit.transform.rotation);
                    Destroy(hiteffect, 1);
                    if(HP.Die)
                    {
                        HP.SnockBack();
                    }
                }
            }

            if (hit.gameObject.CompareTag("BossOrc"))
            {
                var HPBoss = hit.GetComponent<OrcHealth>();
                if (HPBoss)
                {
                    
                    HPBoss.TakeDamage(Damage);

                    var hiteffect = Instantiate(HitEffect, hit.transform.position, hit.transform.rotation);
                    Destroy(hiteffect, 1);

                }

            }
            

        }
    }

    public void SpecialSkillSword()
    {
        
        var effect = Instantiate(effectSkillSpecial, LaserEffect.transform.position , LaserEffect.transform.rotation);
        LaserEffect.SetActive(true);
        Destroy(effect, 2);
        var euf = Instantiate(EffectUnderFoot, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        Destroy(euf, 1f);
        CinematicSkill();
        
    }

    private void CinematicSkill()
    {
        CameraSkill.SetActive(true);
        Time.timeScale = valueScale;
        isScale = true;
        
        
    }
    public void TurnOffLaserEffect()
    {
        LaserEffect.SetActive(false);
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, PointRadius);

    }

    public void SLashAirHit1()
    {
        hit1.Emit(1);
    }
    public void PlayMFXFlash()
    {
        audioSource.PlayOneShot(MFXSwordAir);
    }
}
