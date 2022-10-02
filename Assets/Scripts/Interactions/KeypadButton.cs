using System.Collections;
using UnityEngine;

public class KeypadButton : Prop {
	[SerializeField]
	private Entity entity;

	[SerializeField]
	private int value;

	[SerializeField]
	private Keypad keypad;

	[SerializeField]
	private float animationLength = 0.2f;

	public void Bind(Keypad keypad) {
		this.keypad = keypad;
	}

	protected override void Activate() {
		StartCoroutine(Press());
    }

	private IEnumerator Press() {
		entity.ViewNext();

		yield return new WaitForSeconds(animationLength);

		entity.ViewNext();
		keypad.Press((char)('0' + value));
	}
}