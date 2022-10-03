using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temp removing hairpin logic to simplify puzzle for initial release
public class CassettePlayer : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private AudioClip drawerSound;
    [SerializeField]
    private AudioClip playerSound;
    [SerializeField]
    private AudioClip clueSound;


    protected override int NumStates => 3;

    protected override void EnterState(int stateNum)
    {
        
        if (stateNum == 0)
        {
            entity.ViewSelection = 0;
        }
        else if (stateNum == 1)
        {
            entity.ViewSelection = 1;
            PlaySound(drawerSound);
        }
        else if (stateNum == 2)
        {
            entity.ViewSelection = 1;
            PlaySound(clueSound);
        }
    }


    protected override void Toggle()
    {
        state = Math.Min(state + 1, NumStates - 1);
        EnterState(state);
    }


}

/*
protected override void EnterState(int stateNum)
{
    if (stateNum == 2)
    {
        entity.ViewSelection = 1;
        PlaySound(clueSound);
    }
    else if (stateNum == 0)
    {
        entity.ViewSelection = 1;
        PlaySound(drawerSound);
    }
    else
    {
        entity.ViewSelection = 0;
        PlaySound(drawerSound);
    }
}


protected override void Toggle()
{
    if (GameManager.HasItem("Cassette"))
    {
        if(state != 2)
        {
            PlaySound(playerSound);
        }
            state = 2;
            EnterState(state);
    }
    else
    {
        base.Toggle();
    }


}

}
*/