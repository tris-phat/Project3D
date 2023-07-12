using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAttack : MonoBehaviour
{

    [Header("Audio Clip")]
    public AudioSource MFXattack;
    public AudioSource MFXLaught;


    private Animator Anim;
    public bool Captain;
    [Header("Controller Attack")]
    public int Damage;
    public float AreaStartAttack;
    public float AttackRadius;
    public Transform AttackPoint;
    public NavMeshAgent navMeshAgent;
    private bool _attack;
    private Transform _player;
    public bool enemyMeele;


    public float waittime;
    public bool shoot = true;
    public GameObject Arrow;



    public GameObject HammerOnHand;
    public GameObject BombOnHand;
    public GameObject warningBomb;
    GameObject bomb;
    GameObject warning;


    public bool Action;
    Vector3 point;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    float duration;
    public float speed;
    public float Height;

    private void Update()
    {
        float distance = Vector3.Distance(_player.position, transform.position);

        if (Action)
        {
            if (!Captain)
            {

                if (enemyMeele)
                {
                    if (distance <= AreaStartAttack)
                    {
                        navMeshAgent.isStopped = true;
                        _attack = true;
                        MFXattack.Play();


                    }
                    else
                    {
                        navMeshAgent.isStopped = false;
                        _attack = false;

                    }


                }
                else
                {
                    if (distance <= AreaStartAttack)
                    {
                        if (shoot)
                        {
                            StartCoroutine(Shoot());
                        }
                    }
                }


            }
            else
            {
                if (this.GetComponent<EnemyController>().action == true)
                {

                    if (enemyMeele)
                    {
                        HammerOnHand.SetActive(true);
                        BombOnHand.SetActive(!true);

                        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
                        {
                            Anim.SetBool("Shoot", false);
                        }

                        if (distance <= AreaStartAttack)
                        {
                            navMeshAgent.isStopped = true;
                            _attack = true;


                        }
                        else
                        {
                            navMeshAgent.isStopped = false;
                            _attack = false;

                        }
                    }
                    else
                    {
                        HammerOnHand.SetActive(false);
                        BombOnHand.SetActive(!false);
                        if (shoot)
                        {
                            StartCoroutine(Shoot());
                        }
                    }
                }



            }
        }
        else _attack = false;





        SetAnimState(_attack);

        if (bomb != null)
        {
            duration += Time.deltaTime;

            duration = duration % speed;
            print("bullet");

            bomb.transform.position =
                MathParabola.Parabola(bomb.transform.position, point, Height, duration / speed);


        }

    }


    IEnumerator Shoot()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            Anim.SetFloat("Moving", -0.1f);
        }
        Anim.SetBool("Shoot", true);
        MFXLaught.Play();
        shoot = false;

        yield return new WaitForSeconds(waittime);
        BombOnHand.SetActive(true);
        shoot = true;


    }


    public void Bullet()
    {
        BombOnHand.SetActive(false);
        point = _player.transform.position;
        warning = Instantiate(warningBomb, point, Quaternion.identity);
        bomb = Instantiate(Arrow, AttackPoint.transform.position, transform.rotation);



    }

    public void ResetAttack()
    {
        print("reset");
        Anim.SetBool("Shoot", false);

    }

    private void SetAnimState(bool attack) => Anim.SetBool("IsAttack", attack);


    public void HurtPlayer()
    {
        Collider[] Hits = Physics.OverlapSphere(AttackPoint.position, AttackRadius);
        foreach (var hit in Hits)
        {
            var HP = hit.GetComponentInChildren<HealthPoint>();
            if (HP && hit.gameObject.CompareTag("Player"))
            {
                HP.TakeDamage(Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AreaStartAttack);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
    }

}