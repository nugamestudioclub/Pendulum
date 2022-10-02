using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prop : MonoBehaviour
{
    protected abstract void Activate();
    private void OnMouseDown()
    {
        Debug.Log($"{name} was clicked");
        
        Activate();
    }
   
}
