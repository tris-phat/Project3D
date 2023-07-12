using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleCrossHair : MonoBehaviour
{

    private void OnEnable()
    {
        if(gameObject.activeInHierarchy)
        {
            StartCoroutine(scaleCrossHair());
        }
    }


    IEnumerator scaleCrossHair()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.DOScale(0.5f, 0.2f)
      .SetLoops(1)
      .From(3)
      .SetEase(Ease.OutQuad);
        
        
    }

}
