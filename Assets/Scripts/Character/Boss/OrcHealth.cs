using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OrcHealth : MonoBehaviour
{
    public OrcController orcController;
    public GameObject Door;
    public int MaxHP;
    public int CurrentHP;
    [SerializeField]
    private int ExpEnemy;
   

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Animator Anim;

    [Header("HealthBar")]
    public SetValueBar healthBar;
    

    public UnityEvent isDeath;
    public bool isDefend=false;
    public float timeDefend = 0;

    private void Start()
    {


        Player = GameObject.FindGameObjectWithTag("Player");

        Anim = GetComponent<Animator>();
        orcController = GetComponent<OrcController>();
        healthBar.SetMaxValue(MaxHP, CurrentHP);
        CurrentHP = MaxHP;
        healthBar.SetValue(CurrentHP);

    }


    private void Update()
    {
        UpdateUIHealthBar();

        if (isDefend)
        {
            if (timeDefend <= 5)
            {
                timeDefend += Time.deltaTime;


            }
            else
            {
                
                timeDefend = 0;
                isDefend = false;
                Anim.SetBool("isDefend", false);
            }
        }

    }
    public void UpdateUIHealthBar()
    {
        healthBar.SetValue(CurrentHP);

        
    }

   
   
    public void TakeDamage(int damage)
    {
        if (Die) return;
        //CurrentHP -= damage;

        if (isDefend)
        {
            return;
            
        }
        else CurrentHP -= damage; 

        var rd = Random.Range(0, 3);
        switch (rd)
        {
            case 0: break;
            case 1: break;
            case 2:
                {
                    Defend();

                }
                break;
            case 3: break;



        }


        if (Die)
        {
           
            Anim.SetTrigger("Die");
            Death();
            PlusExpPlayer();
            Door.SetActive(false);
            orcController.HPBar.SetActive(false);
        }
    }
   
    private bool Die => CurrentHP <= 0;
    void Defend()
    {

        Anim.SetBool("isDefend", true);
       
        isDefend = true;
        //_agent.isStopped = true;

        print("Defend");
    }

    private void Death()
    {
        isDeath.Invoke();

    }

    public void PlusExpPlayer()
    {
        Player.GetComponent<ExperiencePoint>().AddEXP(ExpEnemy);
    }
}
