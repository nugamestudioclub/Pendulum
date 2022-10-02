using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToggleProp : ToggleProp
{
    [SerializeField]
    private List<Sprite> sprites;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    protected override int NumStates
    {
        get => sprites.Count;
    }

    protected override void EnterState(int stateNum)
    {
        spriteRenderer.sprite = sprites[stateNum];
    }
}
