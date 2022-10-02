using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager instance;

	public static readonly System.Random Random = new();

	public bool isTimeFrozen;
	public static bool IsTimeFrozen => instance.isTimeFrozen;

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

	public float TimeElapsed { get; private set; }

	private float tickTime;

	[SerializeField]
	private float tickLength = 10.0f;

	private float epochTime;

	[SerializeField]
	private float epochLength = 120.0f;

	private int epoch;

	public static int Epoch => instance.epoch;

	public static readonly int EpochCount = 5;

	private void Update() {
		if( !IsTimeFrozen )
			AdvanceTime(Time.deltaTime);
	}

	public static void Bind(Entity entity) {
		instance.entities.Add(entity);
	}

	public static void Freeze() {
		instance.isTimeFrozen = true;
		foreach( var entity in GetEntities() )
			entity.OnFreeze.Invoke(entity);
	}

	public static void Unfreeze() {
		instance.isTimeFrozen = false;
		foreach( var entity in GetEntities() )
			entity.OnUnfreeze.Invoke(entity);
	}

	private void Tick() {
		var entities = GetEntities().ToList();
		var pick = entities[Random.Next(entities.Count)];
		
		pick.OnTick.Invoke(pick);
	}

	private void AdvanceTime(float delta) {
		TimeElapsed += delta;

		tickTime += delta;
		if( tickTime >= tickLength ) {
			Tick();
			tickTime = 0.0f;
		}

		epochTime += delta;
		if( epochTime >= epochLength ) {
			AdvanceEpoch();
			epochTime = 0.0f;
		}
	}

	private void AdvanceEpoch() {
		++epoch;
		foreach( var entity in GetEntities() )
			entity.OnEpoch.Invoke(entity);
	}

	private static IEnumerable<Entity> GetEntities() {
		return instance.entities.Where(e => e != null && e.enabled);
	}
}