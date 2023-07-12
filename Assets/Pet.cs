using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class Pet : MonoBehaviour
{
    public Transform Boss;

    public bool isChasing;
    public float speed;
    public float waittime;
    private NavMeshAgent agent;
    private Animator _anim;

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        if(gameObject.activeInHierarchy)
        {
            StartCoroutine(ChasingBoss());
        }
       
    }

    IEnumerator ChasingBoss()
    {
        var distance = Vector3.Distance(Boss.position, transform.position);
        if(distance > agent.stoppingDistance)
        {
            agent.SetDestination(Boss.localPosition);
            _anim.SetFloat("Moving", agent.speed);

        }
        else _anim.SetFloat("Moving", -0.01f);


        isChasing = true;
        yield return new WaitForSeconds(waittime);
        isChasing = false;
        StartCoroutine(ChasingBoss());

    }
    
   
   

}
