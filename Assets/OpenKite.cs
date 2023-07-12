using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OpenKite : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(new Vector3(0.5f,1,1), 1f)
            .SetEase(Ease.OutBack)
            .SetLoops(1)
            .From(0.1f);



    }
}
