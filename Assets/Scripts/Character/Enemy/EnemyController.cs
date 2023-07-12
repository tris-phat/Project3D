using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public AudioSource MFXWarning;

    public bool Captain;

    public GameObject ImageSurprise;
    private bool SupportBrother;
    [Header("Controller Area Move")]
    [SerializeField]
    public float waittime;
    public float AreaStartMove;
    public float SpeedRotate;
    private Animator _anim;
    private Transform _playerTarget;
    private NavMeshAgent _agent;

    public bool enemyMeele;
    public bool patrol;
    public bool advertise;
    public bool action = false;
    public Transform PastrolPoint;

    public LayerMask mask1;
    public LayerMask mask2;
    public float RadiusCornect;
    private void Awake()
    {
        ImageSurprise.SetActive(false);
    }
    //private void OnEnable()
    //{
    //    if (!Captain)
    //    {
    //        if (enemyMeele)
    //        {
    //            StartCoroutine(ActionEnemy());

    //        }
    //        else StartCoroutine(ActionMagicEnemy());

    //    }
    //    else StartCoroutine(ActionCaptain());

    //}
    void Start()
    {


        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        if (!Captain)
        {
            if (enemyMeele)
            {
                StartCoroutine(ActionEnemy());

            }
            else StartCoroutine(ActionMagicEnemy());

        }
        else StartCoroutine(ActionCaptain());


    }

   

    IEnumerator ActionCaptain()
    {
        float distance = Vector3.Distance(_playerTarget.position, transform.position);


        if (action)
        {
            if (distance >= AreaStartMove / 2)
            {
                print("bomb");
                //Idle();
                LookAtTarget();
                this.GetComponent<EnemyAttack>().enemyMeele = false;

            }
            else
            {
                print("Meele");
                MoveToTarget();
                this.GetComponent<EnemyAttack>().enemyMeele = true;


            }

            if (distance > AreaStartMove)
            {
                Idle();
            }

        }
        else
        {
            Idle();
            StopMoving();
        }
                
        




        yield return new WaitForSeconds(waittime);
        StartCoroutine(ActionCaptain());
    }


    IEnumerator ActionMagicEnemy()
    {
        if(!SupportBrother)
        {
            float distance = Vector3.Distance(_playerTarget.position, transform.position);
            if (distance <= AreaStartMove)
            {

                ImageSurprise.SetActive(true);
                if (advertise)
                {
                    CallHelp();
                   
                }
                else
                {
                    Idle();
                    LookAtTarget();
                }
                

            }
            else ImageSurprise.SetActive(false);

            yield return new WaitForSeconds(waittime);
            StartCoroutine(ActionMagicEnemy());
        }
       
    }

    IEnumerator ActionEnemy()
    {
        if (action)
        {
            if (!SupportBrother)
            {
                float distance = Vector3.Distance(_playerTarget.position, transform.position);
                if (distance <= AreaStartMove)
                {


                    ImageSurprise.SetActive(true);

                    if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                    {
                        _anim.SetBool("Walk", false);

                    }

                    if (advertise)
                    {
                        CallHelp();
                       
                    }
                    else MoveToTarget();


                }
                else if (patrol)
                {

                    if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {

                        Idle();
                    }
                    _agent.SetDestination(PastrolPoint.position);
                    _anim.SetBool("Walk", true);
                }
                else
                {
                    ImageSurprise.SetActive(false);
                    Idle();
                }
            }
            else
            {

                MoveToTarget();
                print("Help brother");
            }
        }
        else
        {
            Idle();
            StopMoving();
        }
        


        yield return new WaitForSeconds(waittime);
       
        StartCoroutine(ActionEnemy());
    }

    private void CallHelp()
    {
      
        LookAtTarget();
        _anim.SetTrigger("CallHelp");
        MFXWarning.Play();
        Collider[] ally = Physics.OverlapSphere(transform.position, RadiusCornect, mask1);
        foreach (var a in ally)
        {
            if (a)
            {
                a.GetComponent<EnemyController>().SupportBrother = true;
            }
        }
        Collider[] DoorUnder = Physics.OverlapSphere(transform.position, RadiusCornect, mask2);
        foreach(var door in DoorUnder)
        {
            if(door)
            {
                print(door);
                door.GetComponent<Reinforcement>().Open = true;
            }

        }
        advertise = false;
    }
  

    private void MoveToTarget()
    {
        LookAtTarget();

        _agent.SetDestination(_playerTarget.localPosition);
        _anim.SetFloat("Moving", _agent.speed);
        


    }

    private void LookAtTarget()
    {
        
        Vector3 dir = (_playerTarget.position - transform.position).normalized;
        Quaternion lookTarget = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * SpeedRotate);
   
    }
  
   
    private void OnDrawGizmosSelected()
    {
        //Draw Area Begin Move
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,AreaStartMove);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadiusCornect);

    }
    private void Idle()
    {
        _anim.SetFloat("Moving", -0.02f);
    }
    public void StopMoving()
    {
        _agent.isStopped = true;
        enabled = false;
    
    }
    
   
}


