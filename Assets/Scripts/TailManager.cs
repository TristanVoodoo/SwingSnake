using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailManager : MonoBehaviour {

	public static int points = 4;
	public Text pointsText;

	void OnEnable()
	{
		Events.Instance.AddListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
	}

	void OnDisable()
	{
		Events.Instance.RemoveListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
	}

	void HandleOnBlockCollided(OnBlockCollidedEvent ev) {
		points--;
		UpdatePoints();
	}

	void Start () {
		UpdatePoints();
	}
	
	public void UpdatePoints () {
		pointsText.text = points.ToString();
	}
}
