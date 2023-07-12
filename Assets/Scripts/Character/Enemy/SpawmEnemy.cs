using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform EnemyContainer;
    [SerializeField]
    private float Radius;
    [SerializeField]
    private GameObject[] EnemyPrefab;
    
    private void Start()
    {
        FirstSpawm();


    }
     void FirstSpawm()
    {
       
        for(int i =0; i < 5;i++)
        {
            int e = Random.Range(0, EnemyPrefab.Length);
            var dir = transform.position + Random.insideUnitSphere * Radius;
            //Instantiate(EnemyPrefab[e], dir, Quaternion.identity).gameObject.transform.SetParent(EnemyContainer);
        }
       


    }

    private void Update()
    {
        Invoke(nameof(CheckAndInstantiateAgain), 100f);
    }
    private void CheckAndInstantiateAgain()
    {
        int e = Random.Range(0, EnemyPrefab.Length);
        
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
