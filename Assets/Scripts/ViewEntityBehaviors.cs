using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = nameof(ViewEntityBehaviors), menuName = Assets.TEMPLATES + "/" + nameof(ViewEntityBehaviors))]
public class ViewEntityBehaviors : ScriptableObject {
	public void ViewNext(Entity entity) {
		entity.ViewNext();
	}

	public void ViewRandom(Entity entity) {
		entity.ViewRandom();
	}

	public void ViewByEpoch(Entity entity) {
		entity.ViewByEpoch();
	}
}