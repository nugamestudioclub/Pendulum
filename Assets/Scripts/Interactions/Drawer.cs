using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Entity cassete;

    [SerializeField]
    private AudioClip drawerSound;
    [SerializeField]
    private AudioClip cassetteSound;
    protected override int NumStates => 4;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 0)
        {
            entity.ViewSelection = 0;
        }
        //enter state 1
        else if (stateNum == 1)
        {
            PlaySound(drawerSound);
            entity.ViewNext();
        }
        //enter state 2
        else if (stateNum == 2)    
        {
            PlaySound(cassetteSound);
            cassete.EnableCollider(true);
            cassete.ShowView(true);
        }
    }

    protected override void Toggle()
    {
        if (GameManager.HasItem("Hairpin"))
        {
            state = Math.Min(state + 1, NumStates - 1);
            EnterState(state);
        }
        
    }

}
