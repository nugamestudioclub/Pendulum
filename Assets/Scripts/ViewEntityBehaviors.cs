using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = nameof(ViewEntityBehaviors), menuName = Assets.TEMPLATES + "/" + nameof(ViewEntityBehaviors))]
public class ViewEntityBehaviors : ScriptableObject {
	public void HideView(Entity entity) {
		entity.ShowView(false);
	}

	public void ShowView(Entity entity) {
		entity.ShowView(true);
	}

	public void ViewNext(Entity entity) {
		entity.ViewNext();
	}

	public void ViewRandom(Entity entity) {
		entity.ViewRandom();
	}

	public void ViewByEpoch(Entity entity) {
		entity.ViewByEpoch();
	}

	public void ResetView(Entity entity)
    {
		entity.ViewSelection = 0;
    }
}