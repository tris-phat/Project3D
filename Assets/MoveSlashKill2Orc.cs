using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSlashKill2Orc : MonoBehaviour
{
   
    void Start()
    {
        transform.DOMoveZ(5, 3f)
            .SetEase(Ease.Linear)
            .SetLoops(1);
            
    }

    
   
}
