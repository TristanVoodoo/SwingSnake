using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPartSpawner : MonoBehaviour {

	public GameObject prefab;
	public float step = 150f;

	void OnEnable()
	{
		Events.Instance.AddListener<OnSpawnTriggeredEvent>(HandleOnSpawnTriggered);
	}

	void OnDisable()
	{
		Events.Instance.RemoveListener<OnSpawnTriggeredEvent>(HandleOnSpawnTriggered); 
	}

	void HandleOnSpawnTriggered(OnSpawnTriggeredEvent ev) {
		SpawnNext(ev.part);
	}

	public void SpawnNext(GameObject part) {
		Vector3 newPos = part.transform.position;
		newPos.x += step;

		WorldPart nextPart = Instantiate(prefab, newPos, Quaternion.identity).GetComponent<WorldPart>();
		nextPart.previousPart = part;
	}
}
