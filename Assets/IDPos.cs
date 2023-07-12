using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class IDPos : MonoBehaviour , IPointerEnterHandler,IPointerExitHandler
{
    public int IDpos;

    public void CheckPos()
    {
        
        GameManager.Instance.MapController.TelePos(IDpos);
        GameManager.Instance.MapUI.SetActive(false);
    }
    public void AnimeChoose()
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       this.transform.DOScale(1.3f, 0.1f).SetEase(Ease.InOutSine).SetLoops(1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(1, 0.1f).SetEase(Ease.InSine).SetLoops(1);
    }
}
