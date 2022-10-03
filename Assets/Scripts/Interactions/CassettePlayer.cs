using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassettePlayer : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Entity photo;

    [SerializeField]
    private AudioClip drawerSound;
    [SerializeField]
    private AudioClip playerSound;
    [SerializeField]
    private AudioClip clueSound;


    protected override int NumStates => 2;

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
