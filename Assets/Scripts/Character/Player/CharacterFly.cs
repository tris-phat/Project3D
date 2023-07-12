using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFly : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    private CharacterJump Gliding;
    
    [SerializeField]
    private CharacterMove _move;
    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Gliding._isGliding)
        {
            _move.enabled = false;
            transform.position = Camera.main.transform.forward * y * Speed ;




        }
        else _move.enabled = true;

        
    }
}
