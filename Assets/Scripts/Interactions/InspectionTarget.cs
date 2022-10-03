using UnityEngine;

public class InspectionTarget : Prop {
	[field: SerializeField]
	public Entity Entity { get; private set; }

	[SerializeField]
	private GameObject raycastBlocker;

	[SerializeField]
	private Collider exitCollider;

	public bool IsInspecting { get; private set; }

	void Awake() {
		DoAwake();
	}

	protected override void DoAwake() {
		base.DoAwake();

		Entity.ShowView(false);
		if( exitCollider != null )
			exitCollider.enabled = false;
		if( raycastBlocker != null )
			raycastBlocker.SetActive(false);
	}

	public void Inspect() {
		GameManager.Freeze();
		IsInspecting = true;
		Entity.ShowView(true);
		if( exitCollider != null )
			exitCollider.enabled = true;
		if( raycastBlocker != null )
			raycastBlocker.SetActive(true);
	}

	public void Dismiss() {
		GameManager.Unfreeze();
		IsInspecting = false;
		Entity.ShowView(false);
		if( exitCollider != null )
			exitCollider.enabled = false;
		if( raycastBlocker != null )
			raycastBlocker.SetActive(false);
	}

	protected override void Activate() {
		if( IsInspecting )
			Dismiss();
	}
}