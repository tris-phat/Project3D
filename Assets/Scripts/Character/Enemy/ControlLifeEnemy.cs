using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class ControlLifeEnemy : MonoBehaviour
{

    public AudioSource MFXdie;

    public float ForceSnock;
    public float SnockTime;
    public GameObject Trail;

    public int MaxHP;
    public int CurrentHP;
    [SerializeField]
    private int ExpEnemy;


    
    private GameObject Player;
    
    private Animator Anim;

    [Header("HealthBar")]
    public SetValueBar healthBar;
   

    public UnityEvent isDeath;
  


    private void Start()
    {
        Trail.SetActive(false);
        Physics.IgnoreLayerCollision(8, 8);
        Player = GameObject.FindGameObjectWithTag("Player");
       
        Anim = GetComponent<Animator>();

        healthBar.SetMaxValue(MaxHP, CurrentHP);
        CurrentHP = MaxHP;
        healthBar.SetValue(CurrentHP);

    }


    private void Update()
    {
        UpdateUIHealthBar();
    }
    public void UpdateUIHealthBar()
    {
        healthBar.SetValue(CurrentHP);
       
       
    }

   
    public void TakeDamage(int damage)
    {
        if (Die) return;


        CurrentHP -= damage;


        Anim.SetTrigger("Hurt");
   
        if (Die)
        {
            if(MFXdie)
            {
                MFXdie.Play();
            }
            Anim.SetTrigger("Die");
            Death();
            PlusExpPlayer();
        }
    }

    public bool Die => CurrentHP <= 0;

    private void Death()
    {
        isDeath.Invoke();

    }
   

    public void PlusExpPlayer()
    {
        Player.GetComponent<ExperiencePoint>().AddEXP(ExpEnemy);
    }

    public void SnockBack()
    {
        Vector3 point = transform.position + new Vector3(Random.Range(-5,5),0,5);
        transform.DOJump(point, 1, 1, 1);
        Trail.SetActive(true);

    }
    
}
