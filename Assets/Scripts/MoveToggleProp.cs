using System.Collections.Generic;
using UnityEngine;

public class MoveToggleProp : ToggleProp
{
    [SerializeField]
    private List<Transform> stateLocations;

    protected override int NumStates { 
        get => stateLocations.Count;
    }

    protected override void EnterState(int stateNum)
    { 
        transform.position = stateLocations[stateNum].position;
        transform.rotation = stateLocations[stateNum].rotation;
    }
}
