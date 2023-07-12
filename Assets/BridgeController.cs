using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public Transform plane;
    private GameObject bb;
    public bool exploded;
    public float speed = 0.5f;
    private void Start()
    {
       
        bb = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        if(exploded)
        {
            plane.position += Vector3.up * -speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print(other.gameObject.name);
            bb.SetActive(true);
            exploded= true;
        }
    }
}
