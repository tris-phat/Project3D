using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Reinforcement : MonoBehaviour
{
    public Transform Point;
    public float NumberQuality;
    public GameObject[] enemys;
    public float waittime;
    public bool Open;
    
    private Animator anim;
    public bool boss;
    public GameObject cam;
    public GameObject intro;
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if(Open)
        {
            StartCoroutine(InsTantiate());
        }
    }

    GameObject enemy;
    IEnumerator InsTantiate()
    {
       
       
        Open = false;
        int i = 0;
        while(i < NumberQuality)
        {
            var rd = Random.Range(0, enemys.Length);
            enemy = Instantiate(enemys[rd], Point.position, Point.rotation);
            
            yield return new WaitForSeconds(waittime);
            i++;
        }
        if (boss)
        {
            if(enemy!=null)
            {
                GameManager.Instance.pauseGame = true;
                cam.SetActive(true);
                intro.SetActive(true);
                yield return new WaitForSeconds(2f);
                intro.transform.GetChild(0).gameObject.SetActive(true);


                yield return new WaitForSeconds(3);
                intro.SetActive(false);
                cam.SetActive(false);
                //enemy.GetComponent<EnemyController>().action = true;
                //enemy.GetComponent<EnemyAttack>().Action = true;
                GameManager.Instance.pauseGame = false;
                yield return null;



            }

        }


    }
}
