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

	[SerializeField]
	GameObject[] views;

	[CallAccessors(nameof(ViewSelection))]
	[SerializeField]
	private int viewSelection;


	[SerializeField]
	private Collider myCollider;

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

	public void ShowView(bool value) {
		views[viewSelection].SetActive(value);
		if( value )
			ViewSelection = viewSelection;
	}

	public void EnableCollider(bool value) {
		if( myCollider != null )
			myCollider.enabled = value;
	}

	public int ViewCount => views.Length;

	// This may fire randomly every ten seconds
	[field: SerializeField]
	public UnityEvent<Entity> OnTick { get; private set; }

	// This will fire whenever enough time passes for the game to enter a new epoch
	[field: SerializeField]
	public UnityEvent<Entity> OnEpoch { get; private set; }

	// This will fire whenever the player interacts with entity
	[field: SerializeField]
	public UnityEvent<Entity> OnInteract { get; private set; }

	// This will fire whenever game time is frozen
	[field: SerializeField]
	public UnityEvent<Entity> OnFreeze { get; private set; }

	// This will fire whenever game time continues from being frozen
	[field: SerializeField]
	public UnityEvent<Entity> OnUnfreeze { get; private set; }

	void Start() {
		GameManager.Bind(this);
	}


	public void ViewNext() {
		++ViewSelection;
	}

	public void ViewRandom() {
		int selection = GameManager.Random.Next(ViewCount - 1);

		ViewSelection = selection < ViewSelection ? selection : selection + 1;
	}

	public void ViewByEpoch() {
		ViewSelection = (int)(ViewCount * ((float)GameManager.Epoch / GameManager.EpochCount));
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