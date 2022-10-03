using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tally : MonoBehaviour {
	[field: SerializeField]
	public int Id { get; private set; }

	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public Sprite Sprite {
		get => spriteRenderer.sprite;
		set => spriteRenderer.sprite = value;
	}
}