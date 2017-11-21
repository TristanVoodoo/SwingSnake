using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPartTrigger : MonoBehaviour {

	public WorldPart worldPart;

	private void OnTriggerEnter2D(Collider2D other) {
		worldPart.OnTrigger();
	}
}
