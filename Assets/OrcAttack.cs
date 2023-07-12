using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class OrcAttack : MonoBehaviour
{

    [Header("Controller Attack")]
    public int Damage;
    public GameObject HitEffect;

    public GameObject effectSkill1;
    public GameObject effectSkill2;
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public float timeDizzy=0;
    public bool isDizzy;

    public float AttackRadius;
    public Transform AttackPoint;

    private bool _attack;
    private Transform _player;
    private Animator _anim;


    public bool Action;
    public UnityEvent Victory;
    GameObject x;
    GameObject y;
    GameObject z;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
      
    }
    private void Update()
    {
        
        float distance = Vector3.Distance(_player.position, transform.position);
        if (!GameManager.Instance.Die)
        {
            if (distance <= AttackRadius)
            {

                _attack = true;


            }
            else
            {

                _attack = false;

            }

        }
        else
        {
            _attack = false;
           
        }

       
       

        SetAnimState(_attack);

        if(isDizzy)
        {
            if(timeDizzy <=3)
            {
                timeDizzy += Time.deltaTime;
            }
            else
            {
                timeDizzy = 0;
                isDizzy = false;
                _anim.SetBool("Dizzy", isDizzy);
           
            }
        }

    }
    private void SetAnimState(bool attack) => _anim.SetBool("IsAttacking", attack);

    public void HurtPlayer()
    {
        Collider[] Hits = Physics.OverlapSphere(AttackPoint.position, AttackRadius);
        foreach (var hit in Hits)
        {

            if(hit.gameObject.CompareTag("Player"))
            {
                var defend = hit.GetComponentInChildren<Animator>();
                var HP = hit.GetComponent<HealthPoint>();
                if (HP)
                {
                    HP.TakeDamage(Damage);
                    var hiteffect = Instantiate(HitEffect, hit.transform.position, hit.transform.rotation);
                    Destroy(hiteffect, 2f);

                }
                if (defend.GetCurrentAnimatorStateInfo(3).IsName("Defend"))
                {
                    _attack = false;
                    isDizzy = true;
                    _anim.SetBool("Dizzy", isDizzy);
                    print("Dizzy");

                }
            }
           


        }
    }



    public void Skill1()
    {
        _anim.SetTrigger("Skill1");
    }
    public void EffectSkill1()
    {
        var ef = Instantiate(effectSkill1, transform.position, transform.rotation);
        Destroy(ef, 3.5f);
    }
    public void Skill2()
    {
        _anim.SetTrigger("Skill2");
        print("skill 2");
    }

    public void EffectSkill2()
    {
        x = Instantiate(effectSkill2, point1.position, transform.rotation);
        Destroy(x, 10f);

        y =  Instantiate(effectSkill2, point2.position, transform.rotation);
        Destroy(y, 10f);

        z = Instantiate(effectSkill2, point3.position, transform.rotation);
        Destroy(z, 10f);
       
    }
    private void FixedUpdate()
    {
        if(x!=null || y != null || z != null)
        {
            x.transform.Translate(point1.transform.forward * 20 * Time.fixedDeltaTime, Space.World);
            y.transform.Translate(point2.transform.forward * 20 * Time.fixedDeltaTime, Space.World);
            z.transform.Translate(point3.transform.forward * 20 * Time.fixedDeltaTime, Space.World);
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
    }
    public void StopAttack()
    {
        enabled = false;
    }

}
