using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour {

	public List<Block> blocks;

	void Start()
	{
		blocks.Shuffle();
		blocks[0].transform.localPosition = new Vector3(0, 6, 0);
		blocks[1].transform.localPosition = new Vector3(0, 0, 0);
		blocks[2].transform.localPosition = new Vector3(0, -6, 0);
	}

	public void Disable() {
		Destroy(gameObject);
		/*foreach(Block block in blocks) {
			block.Disable();
		}*/
	}
}
