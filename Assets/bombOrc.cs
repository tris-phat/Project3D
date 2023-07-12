using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombOrc : MonoBehaviour
{
    public GameObject bigbang;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Warning"))
        {
            Instantiate(bigbang, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
