using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

	public DistanceJoint2D joint;
	public LineRenderer line;
	public float targetDistance = 0f;

	public float distanceStep = 0.1f;
	private float minDistance = -1f;

	private Vector3 target;

	private bool activated = false;

	void Start()
	{
		target = joint.connectedAnchor;
	}

	void Update()
	{
		line.SetPosition(0, transform.position);
	}

	void FixedUpdate()
	{
		if(activated) {
			if(joint.distance > minDistance) {
				joint.distance -= distanceStep;
			}
		}
		line.SetPosition(0, transform.position);
	}

	public void cast () {
		target.x = transform.position.x + targetDistance;

		joint.connectedAnchor = target;
		joint.enabled = true;

		line.SetPosition(0, transform.position);
		line.SetPosition(1, target);
		line.enabled = true;

		activated = true;
	}

	public void stop () {
		joint.enabled = false;
		line.enabled = false;
		activated = false;
	}
}
