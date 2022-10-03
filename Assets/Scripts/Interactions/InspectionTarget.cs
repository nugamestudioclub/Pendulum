using UnityEngine;

public class InspectionTarget : Prop {
	[SerializeField]
	private Entity entity;

	[SerializeField]
	private GameObject raycastBlocker;

	public bool IsInspecting { get; private set; }

	void Awake() {
		entity.ShowView(false);
		if( raycastBlocker != null )
			raycastBlocker.SetActive(false);
	}

	public void Inspect() {
		IsInspecting = true;
		entity.ShowView(true);
		if( raycastBlocker != null )
			raycastBlocker.SetActive(true);
	}

	public void Dismiss() {
		IsInspecting = false;
		entity.ShowView(false);
		if( raycastBlocker != null )
			raycastBlocker.SetActive(false);
	}

	protected override void Activate() {
		if( IsInspecting )
			Dismiss();
	}
}