using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : ToggleProp {
	[SerializeField]
	private Entity entity;

	[SerializeField]
	private Entity key;

	[SerializeField]
	private AudioClip tapSound;

	[SerializeField]
	private AudioClip keySound;

	protected override int NumStates => 7;

	protected override void EnterState(int stateNum) {
		if( stateNum == 0 ) {
			entity.ViewSelection = 0;
		}
		else if( stateNum == NumStates - 2 ) {
			PlaySound(tapSound);
			GameManager.PlayOneShot(keySound);
			key.EnableCollider(true);
			key.ShowView(true);
			entity.ViewNext();
		}
		else if( stateNum < NumStates - 1 ) {
			PlaySound(tapSound);
			entity.ViewNext();
		}
	}

	protected override void Toggle() {
		state = Math.Min(state + 1, NumStates - 1);
		EnterState(state);
	}
}