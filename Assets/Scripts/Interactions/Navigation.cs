using System.Collections;
using UnityEngine;

// ReSharper disable CompareOfFloatsByEqualityOperator

public class Navigation : MonoBehaviour {
	[SerializeField]
	private float rotationseconds = 0.5f;

	private Vector3 startingPosition;

	private Quaternion startingRotation;

	private bool _isRotating;

	void Awake() {
		startingPosition = transform.position;
		startingRotation = transform.rotation;
	}

	void Update() {
		if( GetLeft() )
			Turn(Vector2.left);
		else if( GetRight() )
			Turn(Vector2.right);
	}

	public void Restart(Entity entity) {
		transform.SetPositionAndRotation(startingPosition, startingRotation);
	}

	private bool GetLeft() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);

	private bool GetRight() => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

	//rotate the object depending on the keys pressed
	private void Turn(Vector2 direction) {
		if( _isRotating )
			return;

		var eulerAngles = transform.eulerAngles;
		float offset = Mathf.Sign(direction.x) * 90;

		Quaternion desiredRotQ = Quaternion.Euler(eulerAngles.x, eulerAngles.y + offset, eulerAngles.z);
		StartCoroutine(SmoothRotate(desiredRotQ));
	}

	IEnumerator SmoothRotate(Quaternion desiredRotQ) {
		if( !_isRotating ) {
			_isRotating = true;
			float currentRotatonSecs = 0;
			while( currentRotatonSecs < rotationseconds ) {
				currentRotatonSecs += Time.deltaTime;
				transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Mathf.Clamp(currentRotatonSecs / rotationseconds, 0f, 1f));
				yield return null;
			}
			_isRotating = false;
		}

	}
}