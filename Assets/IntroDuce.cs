using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroDuce : MonoBehaviour
{
    
    private void OnEnable()
    {
        transform.DOMoveX(500, 1f).SetLoops(1).SetEase(Ease.Linear) ;
    }
}
