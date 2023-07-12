using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public static Character Instance;

    public Transform TransformPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else return;
    }
    private void Start()
    {
        TransformPlayer = this.gameObject.transform;
    }

}
