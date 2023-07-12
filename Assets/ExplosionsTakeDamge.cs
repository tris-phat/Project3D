using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsTakeDamge : MonoBehaviour
{
    public float radius;
    public int Damage;

    private void Start()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius);
        foreach(var h in hit)
        {
            if(h.gameObject.CompareTag("Player"))
            {
                h.GetComponent<HealthPoint>().TakeDamage(Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
