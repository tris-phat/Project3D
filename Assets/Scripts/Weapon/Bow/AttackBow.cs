using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AttackBow : MonoBehaviour
{
    [Header("MFX")]
    public AudioSource audioSource;

    public AudioClip MFXAttackBow;
    public AudioClip MFXWaitArrow;
    public AudioClip MFXShoot;


    public float x;
    public float y;
    private Animator Anim;
    public GameObject CrossHair;
    public GameObject FireTransForm;
    public GameObject WaitPoint;
    public GameObject ArrowPrefab;
    public GameObject ArrowBBPrefab;
    public float Force;
    Vector3 targetpoint;

    public bool Firearrow;
    GameObject obj;


    private void Start()
    {
        Anim = GetComponentInParent<Animator>();
    
    }
    
    private void FixedUpdate()
    {
        if(CrossHair.activeInHierarchy)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(x, y, 0));

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
               
                targetpoint = hitInfo.point;
               

                if (!hitInfo.collider.CompareTag("Player"))
                {
                    //targetpoint = hitInfo.point;
                    Debug.DrawLine(FireTransForm.transform.position, targetpoint, Color.red);
                    CrossHair.GetComponent<Image>().color = Color.green;
                    targetpoint = hitInfo.point;
                }

            }
            else
            {
                 
                targetpoint = ray.GetPoint(100f);
                Debug.DrawRay(FireTransForm.transform.position, targetpoint, Color.yellow);
            }

            if (Firearrow)
            {
                FireArrow();
                gameObject.GetComponentInChildren<Bow>().isFireArrow = Firearrow;
            }

           
        }
        Anim.SetBool("ArrowFire", Firearrow);
    }
    private void FireArrow()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
            Firearrow = true;
            

        }
    }

    public void Shoot()
    {
    
        if(!Firearrow)
        {
            var arrow = Instantiate(ArrowPrefab, transform.position, FireTransForm .transform.rotation);
            var Damge = GetComponentInChildren<Bow>().Damage;
            arrow.GetComponent<flyingTarget>().Damage = Damge;
            arrow.GetComponent<Rigidbody>().velocity = (targetpoint - FireTransForm.transform.position).normalized * Force;

            //arrow.transform.position = Vector3.MoveTowards(arrow.transform.forward, targetpoint, Force);
            //arrow.GetComponent<Rigidbody>().AddForce()
            
            
        }
        else
        {
            
            var Damge = GetComponentInChildren<Bow>().Damage;
            if(obj!=null)
            {
                obj.GetComponent<flyingTarget>().Damage = Damge;
                obj.transform.SetParent(null);
                obj.GetComponent<Rigidbody>().isKinematic = false;
                obj.GetComponent<Rigidbody>().velocity =   (targetpoint - transform.position).normalized * Force;
                obj.transform.GetChild(1).gameObject.SetActive(true);
               
            }
            
        }

        
    }
    public void PlayMFX()
    {
        audioSource.PlayOneShot(MFXAttackBow);
    }
    public void PlayMFXWaitShoot()
    {
        audioSource.PlayOneShot(MFXWaitArrow);
    }
   
    public void PlayerMFXShoot()
    {
        audioSource.PlayOneShot(MFXShoot);
    }
    public void ArrowBB()
    {
       
        obj = Instantiate(ArrowBBPrefab, WaitPoint.transform.position, WaitPoint.transform.rotation);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(WaitPoint.transform);
    }
    public void EndFireArrow()
    {
        Firearrow = false;
        gameObject.GetComponentInChildren<Bow>().isFireArrow = false;
    }
   

    




}
