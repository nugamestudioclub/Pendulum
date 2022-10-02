using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = nameof(ViewEntityBehaviors), menuName = Assets.TEMPLATES + "/" + nameof(ViewEntityBehaviors))]
public class ViewEntityBehaviors : ScriptableObject {
	public void ViewNext(Entity entity) {
		++entity.ViewSelection;
	}

	public void ViewRandom(Entity entity) {
		int selection = GameManager.Random.Next(entity.ViewCount - 1);

		entity.ViewSelection = selection < entity.ViewSelection ? selection : selection + 1;
	}

	public void ViewByEpoch(Entity entity) {
		entity.ViewSelection = (int)(entity.ViewCount * ((float)GameManager.Epoch / GameManager.EpochCount));
	}
}