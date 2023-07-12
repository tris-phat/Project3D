using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoundFire : MonoBehaviour 
{
    public string NameSkill;
    public int DamageSkill;
    public int SkillNeedMana;

    public GameObject hitEffect;
    public Transform PointAttack;
    public float Radius;

    private Animator Anim;
    private ManaPoint _mpPoint;
    

    private void OnValidate()
    {
        Anim = GetComponentInParent<Animator>();
        _mpPoint = GetComponentInParent<ManaPoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(_mpPoint.CurrentMana >= SkillNeedMana)
            {
                _mpPoint.SubTracMana(SkillNeedMana);
                Anim.SetTrigger(NameSkill);
            
            }
            
        }
    
    }
    public void HurtEnemyAttackSkill()
    {
        Collider[] hits = Physics.OverlapSphere(PointAttack.position, Radius);
        foreach (var hit in hits)
        {
            var HP = hit.GetComponent<ControlLifeEnemy>();
            if (HP)
            {
                HP.TakeDamage(DamageSkill);
                var effect = Instantiate(hitEffect, hit.transform.position, hit.transform.rotation);
                Destroy(effect, 1);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PointAttack.position, Radius);
    }


}
