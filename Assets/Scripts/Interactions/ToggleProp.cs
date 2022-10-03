using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class ToggleProp : Prop
{
    public int state;

    protected abstract int NumStates { get; }
    protected virtual void Toggle()
    {
        state++; 
        state %= NumStates;
        EnterState(state);
    }

    protected abstract void EnterState(int stateNum);

    protected override void Activate()
    {
        Toggle();
    }

    public virtual void Restart (Entity entity)
    {
        state = 0;
        EnterState(0);
    }
}
