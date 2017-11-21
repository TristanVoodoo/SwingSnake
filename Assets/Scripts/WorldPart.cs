using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawnTriggeredEvent : GameEvent {
	public GameObject part;
}
public class WorldPart : MonoBehaviour {

	public GameObject previousPart;
	public WorldPartSpawner spawner;

	public void OnTrigger() {
		Destroy(previousPart);
		Events.Instance.Raise(new OnSpawnTriggeredEvent() { part = gameObject });
	}
}
