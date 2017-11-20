using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBlockCollidedEvent : GameEvent {

}

public class OnBlockDestroyedEvent : GameEvent {

}

public class Block : MonoBehaviour {

	public int points = 0;
	public Text pointsText;

	void Start () {
		if(points < 1) {
			points = Random.Range(1, TailManager.points);
		}
		UpdatePoints();
	}

	public IEnumerator HitBlock() {
		Events.Instance.Raise(new OnBlockCollidedEvent());
		points--;
		UpdatePoints();
		if(points < 1) {
			Die();
		}
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(HitBlock());
	}
	
	public void UpdatePoints () {
		pointsText.text = points.ToString();
	}

	void Die() {
		Events.Instance.Raise(new OnBlockDestroyedEvent());
		Destroy(gameObject);
	}
}
