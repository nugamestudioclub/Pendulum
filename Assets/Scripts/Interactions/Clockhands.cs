using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clockhands : MonoBehaviour {
	[SerializeField]
	private Clockhand secondHand;
	[SerializeField]
	private Clockhand minuteHand;
	[SerializeField]
	private Clockhand hourHand;

	[SerializeField]
	private AudioClip exitSound;


	private void Update() {
		if( secondHand.NumberPointing == GameManager.SecondWin &&
			minuteHand.NumberPointing == GameManager.MinuteWin &&
			hourHand.NumberPointing == GameManager.HourWin ) {
			if( exitSound != null )
				GameManager.PlayOneShot(exitSound);
			StartCoroutine(Win.ExitToCredits());
		}
	}
}
