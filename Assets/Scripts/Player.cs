using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Rigidbody2D body;
	public SpriteRenderer sprite;
	public GrapplingHook grapplingHook;
	public ParticleSystem deathParticles;

	private bool dead = false;
	private bool started = false;
	private Vector3 oldVelocity = Vector3.zero;
	private bool collided = false;

	void OnEnable()
	{
		Events.Instance.AddListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
		Events.Instance.AddListener<OnBlockDestroyedEvent>(HandleOnBlockDestroyed);
	}

	void OnDisable()
	{
		Events.Instance.RemoveListener<OnBlockCollidedEvent>(HandleOnBlockCollided);
		Events.Instance.RemoveListener<OnBlockDestroyedEvent>(HandleOnBlockDestroyed);
	}

	void HandleOnBlockCollided(OnBlockCollidedEvent ev) {
		collided = true;
	}

	void HandleOnBlockDestroyed(OnBlockDestroyedEvent ev) {
		body.velocity = oldVelocity;
		collided = false;
	}

	void Start()
	{

	}
	
	void Update () {
		if(!started) {
			if (Input.GetMouseButtonDown(0)) {
				started = true;
				grapplingHook.stop();
			}
		} else if(!dead) {
			if (Input.GetMouseButtonDown(0)) {
				grapplingHook.cast();
			} else if(Input.GetMouseButtonUp(0)) {
				grapplingHook.stop();
			}
		}

		if(!collided) {
			oldVelocity = body.velocity;
		}
	}

	public void Die() {
		if(!dead) {
			dead = true;
			sprite.enabled = false;
			deathParticles.gameObject.SetActive(true);
			grapplingHook.stop();
			StartCoroutine(Respawn());
		}
	}

	IEnumerator Respawn() {
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Game");
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(!dead) {
			if(other.transform.tag == "Wall") {
				grapplingHook.stop();
			}
		}
	}
}
