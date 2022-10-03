using UnityEngine;

public class LockProp : Prop {
	[SerializeField]
	private string key;

	[SerializeField]
	private Entity entity;

	protected override void Activate() {
		if( GameManager.HasItem(key) ) {
			entity.ViewNext();
			entity.ShowView(true);
			entity.EnableCollider(false);
		}
	}
}