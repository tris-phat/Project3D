using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashOrc : MonoBehaviour
{
    public int Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hit Player");
            var hp = other.GetComponent<HealthPoint>();
            if(hp)
            {
                hp.TakeDamage(Damage);
            }

        }
           
    }

    

}
