using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailManager : MonoBehaviour {

	public static int points = -1;

	public int startingPoints = 4;
	public Text pointsText;
	public Player player;
    public GameObject[] tails;
	public Positions PlayerPositions;
    private float delay = 0.05f;

	public class Positions
    {
    	public AnimationCurve x = new AnimationCurve();
    	public AnimationCurve y = new AnimationCurve();
	}

	void OnEnable()
	{
		Events.Instance.AddListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
		Events.Instance.AddListener<OnBonusTakenEvent>(HandleOnBonusTaken);
	}

	void OnDisable()
	{
		Events.Instance.RemoveListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
		Events.Instance.RemoveListener<OnBonusTakenEvent>(HandleOnBonusTaken);
	}

	void HandleOnBlockCollided(OnBlockCollidedEvent ev) {
		//points--;
		points -= ev.score;
		UpdatePoints();
		if(points < 1) {
			player.Die();
		}
	}

	void HandleOnBonusTaken(OnBonusTakenEvent ev) {
		points += ev.score;
		UpdatePoints();
	}

	void Start () {
		points = startingPoints;
		UpdatePoints();
		PlayerPositions = new Positions();
	}
	
	public void UpdatePoints () {
		pointsText.text = points.ToString();
	}

	/*void FixedUpdate() {
		PlayerPositions.x.AddKey(Time.time, player.transform.position.x);
		PlayerPositions.y.AddKey(Time.time, player.transform.position.y);

		float i = 0.5f;
		foreach (var tail in tails)
		{
			float x = PlayerPositions.x.Evaluate(Time.time - delay * i);
			float y = PlayerPositions.y.Evaluate(Time.time - delay * i);
			Vector3 newpos = new Vector2(x, y);
			tail.transform.position = newpos;
			i++;
		}
    }*/

}
