using UnityEngine;
using System.Collections;

public abstract class Prop : MonoBehaviour {
	public AudioClip sound;

	private AudioSource audioSource;

	void Awake() {
		DoAwake();
	}

	protected virtual void DoAwake() {
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

	public void PlaySound(AudioClip audioClip) {
		audioSource.PlayOneShot(audioClip);
	}
}