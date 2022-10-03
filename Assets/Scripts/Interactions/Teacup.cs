using System;
using UnityEngine;

public class Teacup : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Entity glass;

    [SerializeField]
    private AudioClip spillSound;
    [SerializeField]
    private AudioClip glassSound;
    protected override int NumStates => 4;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 0)
        {
            entity.ViewSelection = 0;
        }
        //enter state 1
        else if (stateNum == 1)//click first time -> knock over
        {
            PlaySound(spillSound);
            entity.ViewNext();
        }
        //enter state 2
        else if (stateNum == 2)     //second time -> glass falls out
        {
            PlaySound(glassSound);
            glass.EnableCollider(true);
            glass.ShowView(true);
        }
    }

    protected override void Toggle()
    {
        state = Math.Min(state + 1, NumStates - 1);
        EnterState(state);
    }
}
