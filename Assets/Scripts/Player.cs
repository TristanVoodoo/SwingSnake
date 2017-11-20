using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D body;
	public GrapplingHook grapplingHook;

	void Start()
	{
		//body.velocity = new Vector2(10, 0);
	}
	
	void Update () {

		/*if(Input.touchCount > 0) {
			TouchPhase phase = Input.GetTouch(0).phase;

			if(phase == TouchPhase.Began) {
				grapplingHook.cast();
			} else if (phase == TouchPhase.Ended){
				grapplingHook.stop();
			}
		}*/

		if (Input.GetMouseButtonDown(0)) {
			grapplingHook.cast();
		} else if(Input.GetMouseButtonUp(0)) {
			grapplingHook.stop();
		}
	}
}
