using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public LeaderController LeaderController;
    public MouseWandering MouseWandering;

    private void Start()
    {
        MouseWandering.enabled = false;
    }
    private void Update()
    {
        if(!LeaderController.Done)
        {
            return;
        }
        else
        {
            
            MouseWandering.enabled = true;
        }
    }
}
