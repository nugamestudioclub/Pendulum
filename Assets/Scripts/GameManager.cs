using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager instance;

	void Awake() {
		if( instance == null ) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}

	private readonly List<Entity> entities = new();

	private float tickTime;

	[SerializeField]
	private float tickLength = 10.0f;

	private float epochTime;

	[SerializeField]
	private float epochLength = 60.0f;

	private int epoch;

	private void Update() {
		tickTime += Time.deltaTime;
		if( tickTime > tickLength ) {
			Tick();
			tickTime = 0.0f;
		}

		epochTime += Time.deltaTime;
		if( epochTime > epochLength ) {
			AdvanceEpoch();
			epochTime = 0.0f;
		}
	}

	private static IEnumerable<Entity> GetEntities() {
		return instance.entities.Where(e => e != null && e.enabled);
	}

	public static void Bind(Entity entity) {
		instance.entities.Add(entity);
	}

	private void Tick() {
		foreach( var entity in GetEntities() )
			entity.OnTick.Invoke(entity);
	}

	private void AdvanceEpoch() {
		++epoch;
		foreach( var entity in GetEntities() )
			entity.OnEpoch.Invoke(entity, epoch);
	}
}