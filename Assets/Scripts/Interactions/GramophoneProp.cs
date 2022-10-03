using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneProp : ToggleProp
{
    // change audio scource pitch increase from 0 to 1 every click
    public float pitchIncrease = 0.2f;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    protected override int NumStates => 6;

    protected override void DoAwake()
    {
        base.DoAwake();
        audioSource.pitch = 0f;
    }

    protected override void EnterState(int stateNum)
    {   
        print(stateNum);
        audioSource.pitch = stateNum / ((float)NumStates-1);
        spriteRenderer.sprite = spriteArray[stateNum % 2];
    }
}
