using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaberSkill : MonoBehaviour
{
    public AttackSword Damage;
    public GameObject BigBang;

    private void OnTriggerExit(Collider other)
    {
    
        if(other.CompareTag("Enemy"))
        {
            var bb = Instantiate(BigBang, other.transform.position, Quaternion.identity);
            Destroy(bb, 2);
            var enemy = other.transform.GetComponent<ControlLifeEnemy>();
            if(enemy)
            {
                enemy.TakeDamage(Damage.Damage);
            }    
        }
        if (other.CompareTag("BossOrc"))
        {
            var bb = Instantiate(BigBang, other.transform.position, Quaternion.identity);
            Destroy(bb, 2);
            var orc = other.transform.GetComponent<OrcHealth>();
            if (orc)
            {
                orc.TakeDamage(Damage.Damage);
            }
        }

    }
}
