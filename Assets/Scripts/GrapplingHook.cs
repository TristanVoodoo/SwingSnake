using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

	public DistanceJoint2D joint;
	public LineRenderer line;

	private Vector3 target;

	private bool activated = true;

	void Start()
	{
		target = joint.connectedAnchor;
	}

	void Update()
	{
		if(activated) {
			line.SetPosition(0, transform.position);
		}
	}

	public void cast () {
		target.x = transform.position.x + 10;

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
