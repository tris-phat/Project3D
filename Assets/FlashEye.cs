using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashEye : MonoBehaviour
{
    Vector3 CloseEye = new Vector3(0.1f, 0, 0);
    public float Speed;
    public float timer=0;
    
    private void Update()
    {
        if(timer <=10)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (transform.localScale.x >= 0)
            {
                transform.localScale -= CloseEye * Speed * Time.deltaTime;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                
                timer = 0;
            }
        }
        
        
    }
    


}
