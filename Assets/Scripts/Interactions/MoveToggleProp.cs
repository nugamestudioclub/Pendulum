using System.Collections.Generic;
using UnityEngine;

public class MoveToggleProp : ToggleProp
{
    [SerializeField]
    private List<Transform> stateLocations;

    protected override int NumStates => stateLocations.Count;

    protected override void EnterState(int stateNum)
    {
        var transform1 = transform;
        transform1.position = stateLocations[stateNum].position;
        transform1.rotation = stateLocations[stateNum].rotation;
    }
}
