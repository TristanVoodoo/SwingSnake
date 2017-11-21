using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBonusTakenEvent : GameEvent {
	public int score = 0;
}

public class Bonus : MonoBehaviour {

	public static int bonusMin = 1;
	public static int bonusMax = 5;

	public Text pointsText;

	public int points;
	
	private void Start() {
		if(points < 1) {
			points = Random.Range(bonusMin, bonusMax);
		}
		UpdatePoints();
	}

	public void UpdatePoints () {
		pointsText.text = points.ToString();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Player") {
			Events.Instance.Raise(new OnBonusTakenEvent() { score = points });
			Destroy(gameObject);
		}
	}
}
