using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatusVFX : MonoBehaviour
{
    public TrailRenderer Trail;

    public void TurnOnVFX()
    {
        ChangeStatus(true);
    }
    public void TurnOffVFX()
    {
        ChangeStatus(false);
    }
    private void ChangeStatus(bool value)
    {
        Trail.emitting = value;
    }
    
}
