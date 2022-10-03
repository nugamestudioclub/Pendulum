using UnityEngine;
using System.Collections;

public abstract class Prop : MonoBehaviour
{
    public AudioClip sound;
    protected abstract void Activate();

    private void OnMouseDown()
    {
        AudioSource audiosc = gameObject.GetComponent<AudioSource>();
        Debug.Log($"{name} was clicked");
        if (audiosc  == null)
        {
            audiosc = gameObject.AddComponent<AudioSource>();
        }
        
        audiosc.clip = sound;
        audiosc.Play();
        Activate();
    }
}