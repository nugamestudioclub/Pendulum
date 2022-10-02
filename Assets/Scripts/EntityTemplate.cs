using UnityEngine;
using UnityEngine.Events;
using Utils;

[CreateAssetMenu(fileName = nameof(EntityTemplate), menuName = Assets.TEMPLATES + "/" + nameof(Entity))]
public class EntityTemplate : ScriptableObject {
	[SerializeField]
	GameObject[] views;
	public GameObject[] Views => views;
}
