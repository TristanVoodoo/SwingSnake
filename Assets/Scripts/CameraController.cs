using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float xOffset = 3.5f;

	private Vector3 newPos;

	void Start () {
		newPos = transform.position;
	}
	
	void Update () {
		newPos.x = player.transform.position.x + xOffset;
		transform.position = newPos;
	}
}
