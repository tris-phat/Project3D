using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEditor.Experimental.GraphView;
using static UnityEngine.ParticleSystem;

public class ZoomOutEffect : MonoBehaviour
{
    public float Damage;
    public ParticleSystem particle;
   
   
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();

        transform.DOScale(10, 3f)
            .SetEase(Ease.OutSine)
            .From(1)
            .SetLoops(1);



    }
   



}
       
  
