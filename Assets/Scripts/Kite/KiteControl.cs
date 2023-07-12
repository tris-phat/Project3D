using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteControl : MonoBehaviour
{

    [SerializeField]
    private CharacterController controller;
    public GameObject Player;

    public float moveSpeed;
    public float rotationSpeed;


    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }


    float Yaw;
    float Pitch;
    Vector3 moveVector;

    void Update()
    {
        Pitch = Input.GetAxis("Vertical");
        if(Pitch > 0.01)
        {
            moveVector = Player.transform.forward * Pitch * moveSpeed * Time.deltaTime;
        }
        else moveVector = Player.transform.forward * moveSpeed * Time.deltaTime;

        controller.Move(moveVector);

        Yaw = Input.GetAxis("Horizontal");
    
    }
    void FixedUpdate()
    {
        //controller.Move(moveVector);
        Player.transform.Rotate(0, Yaw * rotationSpeed, 0);
        
    } 
    
}
