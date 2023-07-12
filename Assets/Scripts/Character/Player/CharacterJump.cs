using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public  Animator Anim;
    [Header("Check Grounded")]
    public bool CanJump;
    public bool Jumping;
    public  bool JumpRound;
   
   

    [Header("Control Jump")]
    public float HeightJumpNormal;
    public float HeightJumpRound;
    public float Gravity;

    public float GravityGliding;
    private Vector3 _move;
    private CharacterController controller;

    public GameObject Kite;
    public bool _isGliding;

    private CharacterMove move;
    public KiteControl fly;
    public GameObject CameraFly;

    public bool _openKite;
   
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        move = GetComponent<CharacterMove>();
        fly = GetComponent<KiteControl>();
    }
    private void Update()
    {
        CheckOnGround();
        Jump();

    }

    private void CheckOnGround()
    {
        if (controller.isGrounded)
        {

            CanJump = true;
            Jumping = false;
            JumpRound = false;
            _isGliding = false;

        }
        else
        {
            Jumping = true;
        }

    }

    private void Jump()
    {
        
        if (CanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                CanJump = false;
                if (!CharacterMove._isSprint)
                {

                    Jumping = true;
                    _move.y = HeightJumpNormal;

                }

                else
                {
                    
                    JumpRound = true;
                    Jumping = true;

                    _move.y = HeightJumpRound;

                }
               
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if (!_isGliding)
                {
                    _isGliding = true;
                }
                else _isGliding = false;
                
            }
        }
    
        SetAnimJump(CanJump,Jumping,JumpRound,_isGliding);
        ActiveKite(_isGliding);
    }
    void ActiveKite(bool gliding)
    {
        Kite.SetActive(gliding);
        move.enabled = !gliding;
        fly.enabled = gliding;
        CameraFly.SetActive(gliding);
    }
    private void FixedUpdate()
    {
        if(!_isGliding)
        {
            _move.y += Gravity * Time.fixedDeltaTime;

        }
        else
        {
            _move.y += GravityGliding * Time.fixedDeltaTime;
        }

        controller.Move(_move * Time.fixedDeltaTime);
    }

    private void SetAnimJump(bool canjump,bool jumping,bool jumpround,bool gliding)
    {
        Anim.SetBool("CanJump", canjump);
        Anim.SetBool("Jumping", jumping);
        Anim.SetBool("JumpRound", jumpround);
        Anim.SetBool("Flying", gliding);
    }
    // metod kiểm tra player tiếp xúc với mặt đất
    // nếu tiếp xúc thì CanJump = true (có thể nhảy)
    // và Jumping = false
   

    public void StopMoving()
    {
        enabled = false;
    }
}

