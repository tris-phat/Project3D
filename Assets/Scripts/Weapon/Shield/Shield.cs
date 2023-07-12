using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : AttackManager
{
    public int ShieldID;

    public bool defend;

    public override void Defend()
    {
        defend = true;
    }
    public override void UnDefend()
    {
        defend = false;
    }

}
