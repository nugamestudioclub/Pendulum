using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Entity photo;

    [SerializeField]
    private AudioClip fluffSound;
    [SerializeField]
    private AudioClip tearSound;
    //when no glass collected
    //toggle back and forth between fluff and unfluff

    //when glass collected
    protected override int NumStates => 2;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 2)
        {
            entity.ViewSelection = 2;
            PlaySound(tearSound);
            photo.EnableCollider(true);
            photo.ShowView(true);
        }
        else if (stateNum == 0)
        {
            entity.ViewSelection = 0;
            PlaySound(fluffSound);
        } else
        {
            entity.ViewSelection = 1;
            PlaySound(fluffSound);
        }
        
    }

    protected override void Toggle()
    {
        if (GameManager.HasItem("GlassShard")) {
            if (state != 2)
            {
                state = 2;
                EnterState(state);
            }
            
        }
        else
        {
            base.Toggle();
        }
        
        
    }


}
