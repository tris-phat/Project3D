using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBlack : MonoBehaviour
{
   
    public int DamageSkill;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var HP = other.GetComponent<ControlLifeEnemy>();
            if (HP)
            {
                HP.TakeDamage(DamageSkill);
            }
        }


    }


}
