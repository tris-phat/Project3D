using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayEffectSkill : MonoBehaviour
{
    public ParticleSystem Effect;

    public bool SkillBuff;
    
    
    public void PlayEffect()
    {
        if (gameObject.activeInHierarchy != true)
        {
            return;
        }
        if (!SkillBuff)
        {
            Effect.Emit(1);
        }
        else
        {
            Effect.Play();
        }

    }
    public void PauseEffect()
    {
        Effect.Stop();
    }

}
