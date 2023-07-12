using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using static UnityEditor.Experimental.GraphView.GraphView;
using DG.Tweening;

public class OrcController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip MFXWalk;
    public AudioClip MFXRun;
    public AudioClip MFXChangeStatus;

    public GameObject HPBar;
    public GameObject EffectJump;
    [Header("Controller Area Move")]
    [SerializeField]
    public float RadiusStartMove;
    public float SpeedLookAt;
    public float PowerJump;
    
    public float timer = 0;
  
    private Animator _anim;
    private Transform _playerTarget;
    private NavMeshAgent _agent;
    private OrcHealth _health;
    private OrcAttack skill;

    

    void Start()
    {
        
        _anim = GetComponent<Animator>();
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<OrcHealth>();
        skill = GetComponent<OrcAttack>();
       // StartCoroutine(ActionEnemy());


    }
    float distance;
    private void Update()
    {
        distance = Vector3.Distance(_playerTarget.transform.position, transform.position);
        
       if (distance <= _agent.stoppingDistance)
       {
            
            StopMoving();
           
       }
       
       

        if (distance <= RadiusStartMove)
        {
            HPBar.SetActive(true);
            LookAtTarget();
            if (timer <= 5)
            {
                timer += Time.deltaTime;
                _anim.SetBool("Wait", true);
                
            }
            else
            {
                audioSource.PlayOneShot(MFXChangeStatus);
                _anim.SetBool("Wait", false);
                timer = 0;
                if (_health.CurrentHP == _health.MaxHP)
                {
                    print("100%");
                    WalkToTarget();
                    var rd = Random.Range(0, 3);
                    switch (rd)
                    {
                        case 0: RunToTarget(); break;
                        case 1:
                            {
                                if(distance > _agent.stoppingDistance)
                                {
                                    print("du dieu kien nhay");
                                    JumpToTarget();
                                }
                                else
                                {
                                    return;
                                }
                                
                            }
                            break;
                        case 2: RunToTarget(); break;
                        case 3: RunToTarget(); break;
                    }
                }
                if (_health.CurrentHP >=_health.MaxHP/2 && _health.CurrentHP <= _health.MaxHP * 0.8)
                {
                    print("80%");
                    RunToTarget();
                    var rd = Random.Range(0, 5);
                    switch(rd)
                    {
                        case 0:
                            if (distance > _agent.stoppingDistance)
                            {
                                print("du dieu kien nhay");
                                JumpToTarget();
                            }
                            break;


                        case 1:
                            if (distance > _agent.stoppingDistance)
                            {
                                print("du dieu kien nhay");
                                JumpToTarget();
                            }
                            break;

                        case 2: skill.Skill1(); break;
                        case 3: skill.Skill2(); break;
                        case 4: break;
                        case 5:  break;

                    }


                }
                if(_health.CurrentHP < (_health.MaxHP/2))
                {
                    print("50%");
                    var rd = Random.Range(0, 10);
                    switch(rd)
                    {
                        case 0:
                            if (distance > _agent.stoppingDistance)
                            {
                                print("du dieu kien nhay");
                                JumpToTarget();
                            }
                            break;
                        case 1:
                            if (distance > _agent.stoppingDistance)
                            {
                                print("du dieu kien nhay");
                                JumpToTarget();
                            }; break;
                        case 2: skill.Skill1(); break;
                        case 3: skill.Skill1(); break;
                        case 4: skill.Skill2();break;
                        case 5: skill.Skill2(); break;
                        case 6: RunToTarget();break;
                        case 7: RunToTarget();break;
                        case 8: WalkToTarget();break;
                        case 9: break;



                    }
                }


            }
        }
        else
        {
            HPBar.SetActive(false);
            timer = 0;
            StopMoving();
        }



    }
  


    private void LookAtTarget()
    {

        Vector3 dir = (_playerTarget.transform.position - transform.position).normalized;
        Quaternion lookTarget = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * SpeedLookAt);

    }

   
    void  WalkToTarget()
    {
        _agent.speed = 5;
        _agent.SetDestination(_playerTarget.localPosition);
        _anim.SetBool("isActive", true);
        audioSource.PlayOneShot(MFXWalk);


    }
    void RunToTarget()
    {
        _agent.speed = 10;
        _agent.SetDestination(_playerTarget.localPosition);
        
        _anim.SetBool("isRunning", true);
        audioSource.PlayOneShot(MFXRun);
    
    }
    void JumpToTarget()
    {
   
        transform.DOJump(_playerTarget.transform.localPosition + new Vector3(0,0,-3), PowerJump, 1, 1f);
        var obj = Instantiate(EffectJump, transform.position, transform.rotation);
        Destroy(obj, 3f);
        _anim.SetBool("Wait", false);
        print("Jump");
    
    }
  
   

    public void StopMoving()
    {
        _anim.SetBool("isActive", false);
        _anim.SetBool("isRunning", false);
        _anim.SetBool("isJumping", false);

    }

    

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, RadiusStartMove);

    }
    public void StopMove()
    {
        enabled = false;
    }
}
