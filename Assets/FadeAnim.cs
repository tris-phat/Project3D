using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeAnim : MonoBehaviour
{
    [SerializeField]
    private Transform Up;
    [SerializeField]
    private Transform Down;

    Vector3 pointup;
    private void Start()
    {
        pointup = Up.position;
    }


    private void OnEnable()
    {
        StartCoroutine(BlinkEye());
    }

    public IEnumerator BlinkEye()
    {

        Up.DOMoveY(1200, .3f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-100, .3f).SetLoops(1).SetEase(Ease.Linear);
    
        yield return new WaitForSeconds(.5f);
        Up.DOMoveY(pointup.y, .3f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-1100, .3f).SetLoops(1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false); ;



    }
   
}
