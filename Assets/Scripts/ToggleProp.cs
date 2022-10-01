using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class ToggleProp : Prop
{
    public int state;

    protected abstract int NumStates { get; }
    protected void Toggle()
    {
        EnterState(++state % NumStates);
    }

    protected abstract void EnterState(int stateNum);

    protected override void Activate()
    {
        Toggle();
    }
}
