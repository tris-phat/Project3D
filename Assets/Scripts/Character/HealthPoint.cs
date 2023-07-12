using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public Animator Anim;

    public SetValueBar healthBar;
    public int MaxHP;
    public int _currentHP;

    public bool die;
    public UnityEvent isDeath;
    public bool fall;
    public float timegetup=0;

    public Image Fill;
   
    private void Start()
    {

        //Anim = GetComponentInChildren<Animator>();
        healthBar.SetMaxValue(MaxHP,_currentHP);
        _currentHP = MaxHP;
        healthBar.SetValue(_currentHP);
       
        
    }
    private void Update()
    {
        UpdateUIHealthBar();
        if(fall)
        {

            if (timegetup <= 2)
            {
                timegetup += Time.deltaTime;
                
            }
            else
            {
                Anim.SetTrigger("Getup");
                fall = false;
                timegetup = 0;

            }

        }

       

    }
    public void UpdateUIHealthBar()
    {
        
        if(_currentHP == MaxHP)
        {
            Fill.color = Color.green;
        }
        if(_currentHP <= MaxHP/2)
        {
            Fill.color = Color.yellow;
        }
        if(_currentHP <= MaxHP*0.3)
        {
            Fill.color = Color.red;
        }
        healthBar.SetValue(_currentHP);
    }

    public void ResumeHealth(int value)
    {
       
           
            _currentHP += value;
        
    }

    public void TakeDamage(int damage)
    {
        if (Die) return;

        if (!Anim.GetCurrentAnimatorStateInfo(3).IsName("Defend"))
        {
            _currentHP -= damage;
            Anim.SetTrigger("Hit");

        }
        else print("khong takedame");

      
        if (Die)
        {
        
            Death();
          
        }
    }

    private bool Die => _currentHP <= 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skill1Orc"))
        {
            print(other.name);
            Anim.SetTrigger("Fall");
            fall = true;
            var dm = other.GetComponentInParent<ZoomOutEffect>().Damage;
            TakeDamage((int)dm);


        }
    }

    private void Death()
    {
        print("Anim Die");
        die = true;
        Anim.SetBool("Death", die);
        isDeath.Invoke();
        
    }
}
