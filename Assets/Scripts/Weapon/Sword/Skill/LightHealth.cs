using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightHealth : MonoBehaviour
{
    public string NameSkill;

    public int SkillNeedMana;
    public float TimeSkill;
    private float currentTimeSkill;
    private bool killing;
    private Animator _anim;
    private ManaPoint _mpPoint;
    public UnityEvent StopEffect;

    public void Start()
    {
        _anim = GetComponentInParent<Animator>();
        _mpPoint = GetComponentInParent<ManaPoint>();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(_mpPoint.CurrentMana >= SkillNeedMana)
            {
                _anim.SetTrigger(NameSkill);
                _mpPoint.SubTracMana(SkillNeedMana);
                killing = true;

            }
               
        }

        if(killing)
        {
            if(TimeSkill > currentTimeSkill)
            {
                currentTimeSkill += Time.deltaTime;
            }
            else
            {
                StopEffect.Invoke();
                currentTimeSkill = 0;
                killing = false;
            }
        }
 
    }
}
