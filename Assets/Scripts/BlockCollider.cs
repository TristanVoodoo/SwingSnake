using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour {

	public Block block;

	void OnCollisionEnter2D(Collision2D other)
	{
		StartCoroutine(block.HitBlock());
	}
}
