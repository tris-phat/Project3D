using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject[] rocks;
    private BoxCollider coli;


    public bool AlreadyBigBang;

    private void Start()
    {
        coli = GetComponent<BoxCollider>();
        AlreadyBigBang = false;
    }

    private void Update()
    {
        if (AlreadyBigBang)
        {
           
            BigBang();
        }
    }
    void BigBang()
    {
        foreach(var r in rocks)
        {
            r.SetActive(false);
        }
        coli.enabled = false;
    }

}
