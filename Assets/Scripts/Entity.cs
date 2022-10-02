using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class Entity : MonoBehaviour {
	[CallAccessors(nameof(Template))]
	[SerializeField]
	private EntityTemplate template;

	private EntityTemplate Template {
		get => template;
		set {
			template = value;
			ClearViews();
			CreateViews();
		}
	}

	GameObject[] views;

	[CallAccessors(nameof(ViewSelection))]
	[SerializeField]
	private int viewSelection;

	public int ViewSelection {
		get => viewSelection;
		set {
			if( views == null || views.Length == 0 ) {
				viewSelection = 0;
			}
			else {
				viewSelection = Collections.Normalize(value, template.Views.Length);
				foreach( int i in Enumerable.Range(0, views.Length).Where(x => x != value) )
					views[i].SetActive(false);
				views[viewSelection].SetActive(true);
			}
		}
	}

	public int ViewCount => views.Length;

	// This may fire randomly every ten seconds
	[field: SerializeField]
	public UnityEvent<Entity> OnTick { get; private set; }

	// This will fire whenever enough time passes for the game to enter a new epoch
	[field: SerializeField]
	public UnityEvent<Entity, int> OnEpoch { get; private set; }

	// This will fire whenever the player interacts with entity
	[field: SerializeField]
	public UnityEvent<Entity> OnInteract { get; private set; }

	void Start() {
		GameManager.Bind(this);
	}

	private void ClearViews() {
		if( views == null )
			return;

		foreach( var view in views )
#if UNITY_EDITOR
			DestroyImmediate(view);
#else
			Destroy(view);
#endif
	}

	private void CreateViews() {
		if( template == null ) {
			views = null;
		}
		else {
			views = new GameObject[template.Views.Length];
			for( int i = 0; i < views.Length; ++i )
				views[i] = Instantiate(template.Views[i], transform);
			ViewSelection = viewSelection;
		}
	}
}