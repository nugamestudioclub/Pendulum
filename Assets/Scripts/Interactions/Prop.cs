using UnityEngine;
using System.Collections;

public abstract class Prop : MonoBehaviour {
	public AudioClip sound;

	private AudioSource audioSource;

	void Awake() {
		audioSource =  gameObject.GetComponent<AudioSource>();
		if( audioSource == null )
			audioSource = gameObject.AddComponent<AudioSource>();
	}

	private void OnMouseDown() {
		Debug.Log($"{name} was clicked");

		if( sound != null )
			PlaySound(sound);
		Activate();
	}

	protected abstract void Activate();

	protected void PlaySound(AudioClip audioClip) {
		audioSource.PlayOneShot(audioClip);
	}
}