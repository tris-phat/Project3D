using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    
    public Animator anim;
    private CharacterController _controller;
    public GameObject SmokeSprinting; 


    public float RotationSpeed;
    private float angel;
    [Header("Control speed moving")]
   
    public float Speed;
    public static bool _isSprint;
    public float SpeedSprint;

    [Header("Control thể lực")]
    public SetValueBar PhysicalBar;
    public int MaxPhysical;
    private float _physical;
    public Image FillPhycialColor;
    public UnityEvent ShowPhysicalBar;
    public UnityEvent TurnOfPhysicalBar;

   
    private Vector3 _move;
    private Vector3 moving;
    
   
    public bool getup;
    public float timegetup=2;

    [Header("Control Roll")]
    public bool isRoll;
   
    public float timeRoll;
    private float lasttimeRoll; 
    public float speedRoll;

    public int countNumberpressW = 0;
    public int countNumberpressS = 0;
    public int countNumberpressA = 0;
    public int countNumberpressD = 0;


    public bool isDefend;

    private void Start()
    {
        lasttimeRoll = timeRoll;
        _controller = GetComponent<CharacterController>();
        PhysicalBar.SetMaxValue(MaxPhysical,(int)_physical);
        _physical = MaxPhysical;
        PhysicalBar.SetValue((int)_physical);

        

    }
    private void Update()
    {
        _move.z = Input.GetAxis("Vertical");
        _move.x = Input.GetAxis("Horizontal");

        if(!anim.GetCurrentAnimatorStateInfo(3).IsName("Defend"))
        {
            isDefend = false;
            moving = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * _move;

            if (moving.magnitude > 0)
            {
                angel = Mathf.Atan2(moving.x, moving.z) * Mathf.Rad2Deg;
                if(anim.GetCurrentAnimatorStateInfo(3).IsName("Defend"))
                {
                    isDefend = true;
                }
            }
              

            var targetrotation = Quaternion.Euler(0, angel, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetrotation, RotationSpeed);
        }
        else
        {
            isDefend = true;
            moving = Camera.main.transform.right * _move.x +  Camera.main.transform.forward * _move.z;
            //if (_move.z >= 0.01f)
            //{
            //    transform.localRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            //}
            if(moving.magnitude >0)
            {
                if(!anim.GetCurrentAnimatorStateInfo(3).IsName("Defend"))
                {
                    isDefend = false;
                }
            }
        }
       
        SkillSprint();
        Roll();
        SetAnimationMoving(_move.z, _move.x, _move.sqrMagnitude, _isSprint,isRoll, moving.sqrMagnitude);

    }
    private void InputRoll()
    {


        if (Input.GetKeyDown(KeyCode.W))
        {
            countNumberpressW++;

        }
       
        if (Input.GetKeyDown(KeyCode.S))
        {
            countNumberpressS++;

        }
         
      
        if (Input.GetKeyDown(KeyCode.A))
        {
            countNumberpressA++;

        }
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            countNumberpressD++;

        }
       
    }
    private void Roll()
    {
        InputRoll();
        
        if(countNumberpressW !=0 || countNumberpressS !=0 || countNumberpressA !=0 || countNumberpressD !=0)
        {
            if(timeRoll >0)
            {
                timeRoll -= Time.deltaTime;
                if (countNumberpressW >=2 || countNumberpressS >=2 || countNumberpressA >=2 || countNumberpressD >=2)
                {
                    isRoll = true;
                   
                }
               
                
            }
            else
            {
                countNumberpressW = 0;
                countNumberpressS = 0;
                countNumberpressA = 0;
                countNumberpressD = 0;
                timeRoll = lasttimeRoll;
                isRoll = false;
            }
        }
        
    }




    public void FixedUpdate()
    {
        
        if (_isSprint)
        {
            _controller.SimpleMove(moving * Speed * SpeedSprint);
           
        }
        else 
        {
            _controller.SimpleMove(moving * Speed);
           
        }
        if (isRoll)
        {
            transform.Translate(transform.forward * speedRoll * Time.fixedDeltaTime, Space.World);

        }


    }



    // set animation
    private void SetAnimationMoving(float vinput, float hinput, float moving, bool issprint,bool isroll,float movedefend)
    {
        
        if(!isDefend)
        {
            anim.SetFloat("Move", moving);
        }
        else
        {
            anim.SetFloat("MoveDefend", movedefend);
            anim.SetFloat("X", hinput);
            anim.SetFloat("Y", vinput);
        }
        
        anim.SetBool("MoveSprint", issprint);
        anim.SetBool("isRoll", isroll);



    }



    // metod kiểm tra skill tăng tốc
    private void SkillSprint()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_physical > 0)
            {
                _physical -= Time.deltaTime * 2;
                UpdatePhysicalBar((int)_physical);

                // thêm hiệu ứng bụi khi chạy
                //var smksprint = Instantiate(SmokeSprinting, transform.position, transform.rotation);
                //Destroy(smksprint,1f);

                _isSprint = true;

            }
            else
            {
                _isSprint = false;

            }
            ShowPhysicalBar.Invoke();
        }
        else
        {
            TurnOfPhysicalBar.Invoke();
            _isSprint = false;

        }

        if (_physical < MaxPhysical)
        {
            Invoke(nameof(ResumePhysical), 5);
        }


    }

    //  hồi phục thể lực
    void ResumePhysical()
    {
       
        _physical += Time.deltaTime;
        UpdatePhysicalBar((int)_physical);

        if (_physical >= MaxPhysical)
        {
            _physical = MaxPhysical;
        }
       
    }
    private void UpdatePhysicalBar(int value)
    {
        PhysicalBar.SetValue(value);
        if (value > MaxPhysical / 2)
        {
            FillPhycialColor.color = Color.green;
        }
        else FillPhycialColor.color = Color.Lerp(FillPhycialColor.color, Color.yellow, 1f);

        if (value <= MaxPhysical * 0.3)
        {
            FillPhycialColor.color = Color.Lerp(FillPhycialColor.color, Color.red, 1f);
        }
    }
   
    public void StopMoving()
    {
        enabled = false;
    }
    

}
