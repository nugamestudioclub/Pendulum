using System.Linq;
using UnityEngine;
using Utils;

public class Keypad : MonoBehaviour {
	private string guess = "";

	[SerializeField]
	private Entity chest;

	[SerializeField]
	GameObject[] buttons;

	private void Awake() {
		Randomize();
	}

	public void Press(char c) {
		if( guess.Contains(c) )
			return;

		guess += c;

		if( guess == GameManager.Password )
			Open();
		else if( guess.Length == GameManager.Password.Length )
			Cancel();
	}

	private void Open() {
		Debug.Log(nameof(Open));
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
}