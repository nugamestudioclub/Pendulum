using UnityEngine;

public class Inspector : Prop {
	[SerializeField]
	private InspectionTarget target;

	protected override void Activate() {
		if( !target.IsInspecting )
			target.Inspect();
	}
}