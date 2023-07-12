using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class Bow : AttackManager
{
    public int BowID;
    public int Damage;

    [Header("Control Camera")]
    public float speedrotateX;
    public float speedrotateY;
    public Transform CameraHolder;
    public GameObject Player;
    //public GameObject Cam;
  
    public GameObject Cinemachine;

    public Animator anim;

    public bool isFireArrow;
    public GameObject CrossHair;

    private bool _isCrossHair;
    public bool IsCrossHair
    {
        get => _isCrossHair;
        set
        {
            _isCrossHair = value;
            ControllerCrossHairAndCamCrossHair(_isCrossHair);

        }
    }
   
    private void ControllerCrossHairAndCamCrossHair(bool crosshair)
    {
        CrossHair.SetActive(crosshair);
        Cinemachine.SetActive(crosshair);
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();

    }
    public override void SpeacialSkillBow()
    {
        if(_isCrossHair)
        {
            anim.SetTrigger("SpeacialSkillBow");
        }
    }
    public override void Attack()
    {
        if(_isCrossHair)
        {
            if(!isFireArrow)
            {
                anim.SetTrigger("AttackArrow");
            }
            else
            {
               
                anim.SetBool("ArrowFire", false);
            }
           

        }
       
    }



    public override void Aming()
    {

        Player.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        IsCrossHair = true;
        RotateX();
        RotateY();

    }

    private void RotateX()
    {
        float x = Input.GetAxis("Mouse X");
        Player.transform.Rotate(0, x * speedrotateX, 0);
        
    }
    private void RotateY()
    {
        float y = Input.GetAxis("Mouse Y");
         CameraHolder.transform.Rotate(-y*speedrotateY, 0, 0);
      

    }

    public override void UnDefend()
    {
        IsCrossHair = false;
        CameraHolder.transform.Rotate(0, 0, 0);
    }


}