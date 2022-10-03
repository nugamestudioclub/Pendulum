using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour {
	private static GameManager instance;

	public static readonly System.Random Random = new();

	public bool isTimeFrozen;
	public static bool IsTimeFrozen => instance.isTimeFrozen;

	private readonly List<Entity> entities = new();

	private float timeElapsed;
	public static float TimeElapsed  => instance.timeElapsed;

	private float tickTime;

	[SerializeField]
	private float tickLength = 10.0f;

	public static float TickLength => instance.tickLength;

	private float epochTime;

	[SerializeField]
	private float epochLength = 120.0f;

	private int epoch;

	public static int Epoch => instance.epoch;

	public static readonly int EpochCount = 5;

	[SerializeField]
	private int passwordLength = 4;

	private string password;
	public static string Password => instance.password;

	[SerializeField]
	private List<string> inventory = new();
	void Awake() {
		if( instance == null ) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
		password = GetPassword(passwordLength);

		Debug.Log(password);
	}

	void Start() {
		// Begin epoch 0
		foreach( var entity in GetEntities() )
			entity.OnEpoch.Invoke(entity);
	}

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

	private static string GetPassword(int length) {
		char[] chars = Enumerable.Range(0, length).Select(i => (char)(i + '0')).ToArray();

		Random.Shuffle(chars);

		return new(chars);
	}

	private void Tick() {
		var entities = GetEntities().ToList();
		var pick = entities[Random.Next(entities.Count)];

		pick.OnTick.Invoke(pick);
	}

	private void AdvanceTime(float delta) {
		timeElapsed += delta;

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
		inventory.Clear();
		foreach( var entity in GetEntities() )
			entity.OnEpoch.Invoke(entity);
	}

	private static IEnumerable<Entity> GetEntities() {
		return instance.entities.Where(e => e != null && e.enabled);
	}

	public static void AddItem(string item) {
		instance.inventory.Add(item);
	}

	public static void RemoveItem(string item) {
		instance.inventory.Remove(item);
	}

	public static bool HasItem(string item) {
		return instance.inventory.Contains(item);
	}
}