using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour {

	public Block block;

	void OnCollisionEnter2D(Collision2D other)
	{
		if(!block.disable) {
			block.wall.Disable();
			Events.Instance.Raise(new OnBlockCollidedEvent() {score = block.points});
			block.Die();
			//StartCoroutine(block.HitBlock());
		}
	}
}
