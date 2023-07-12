using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAfterDeath : MonoBehaviour
{
    public GameObject EffectBigBang;
    

   public void BigBang()
   {
        
        GameObject effect =  Instantiate(EffectBigBang, this.transform.position, this.transform.rotation);
        Destroy(effect, 1f);
        Destroy(this.gameObject);
   }
    
}
