using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoad : MonoBehaviour
{
    public GameObject Player;
    public float value;
    public bool chest;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (!chest)
        {
            transform.LookAt(Player.transform.position + new Vector3(0, 2, 0));

        }
        else transform.LookAt(Player.transform.position + new Vector3(0, value, 0));
    }
}
