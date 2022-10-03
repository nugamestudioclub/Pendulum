using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockDoor : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private AudioClip openSound;
    protected override int NumStates => 2;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 0)
        {
            entity.ViewSelection = 0;
        } else
        {
            entity.ViewNext();
            PlaySound(openSound);
        }
    }
}
