using UnityEngine;

public class CollectibleProp : Prop {
	[SerializeField]
	private string item;

	[SerializeField]
	private Entity entity;

	protected override void Activate() {
		GameManager.AddItem(item);
		entity.ShowView(false);
	}
}