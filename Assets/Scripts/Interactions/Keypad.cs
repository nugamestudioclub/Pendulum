using System.Linq;
using UnityEngine;
using Utils;

public class Keypad : MonoBehaviour {
	private string guess = "";

	[SerializeField]
	private Entity chest;

	[SerializeField]
	private GameObject[] buttons;

	[SerializeField]
	private InspectionTarget inspectionTarget;

	[SerializeField]
	private AudioClip lockSound;

	[SerializeField]
	private AudioClip openSound;

	private AudioSource audioSource;

	private void Awake() {
		Randomize();

		audioSource =  gameObject.GetComponent<AudioSource>();
		if( audioSource == null )
			audioSource = gameObject.AddComponent<AudioSource>();
	}

	public void Press(char c) {
		if( guess.Contains(c) )
			return;

		guess += c;

		if( guess == GameManager.Password ) {
			inspectionTarget.PlaySound(openSound);
			Open();
		}
		else if( guess.Length == GameManager.Password.Length ) {
			inspectionTarget.PlaySound(lockSound);
			Cancel();
		}
	}

	private void Open() {
		inspectionTarget.Dismiss();
		inspectionTarget.Entity.ViewNext();
		inspectionTarget.Dismiss();
		chest.ViewSelection = 1;

	}

	private void Close() {
		Debug.Log(nameof(Cancel));
		chest.ViewSelection = 0;
	}

	private void Cancel() {
		guess = "";
	}

	public void Restart(Entity entity) {
		Close();
		Cancel();
	}

	private void Randomize() {
		Vector3[] positions = buttons.Select(b => b.transform.position).ToArray();

		GameManager.Random.Shuffle(positions);
		for( int i = 0; i < buttons.Length; ++i )
			buttons[i].transform.position = positions[i];
	}

	protected void PlaySound(AudioClip audioClip) {
		audioSource.PlayOneShot(audioClip);
	}
}