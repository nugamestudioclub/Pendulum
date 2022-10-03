using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : ToggleProp
{
    [SerializeField]
    private Entity entity;

    [SerializeField]
    private Entity key;

    [SerializeField]
    private AudioClip keySound;
    protected override int NumStates => 5;

    protected override void EnterState(int stateNum)
    {

        if (stateNum == 0)
        {
            entity.ViewSelection = 0;
        }
        else if (stateNum == 5 && !GameManager.HasItem("TurquoiseKey"))
        {
            PlaySound(keySound);
            key.EnableCollider(true);
            key.ShowView(true);
            entity.ViewNext();
        }
        else
        {
            entity.ViewNext();
        }

    }
}
