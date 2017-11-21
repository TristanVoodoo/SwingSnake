using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Rigidbody2D body;
	public float xSpeed = 22.5f;
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
		Instantiate(deathParticles, transform.position, Quaternion.identity);
	}

	void HandleOnBlockDestroyed(OnBlockDestroyedEvent ev) {
		body.velocity = oldVelocity;
		collided = false;
	}

	void Start()
	{
		body.velocity = new Vector3(xSpeed, 0, 0);
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
				Debug.Log(body.velocity);
				body.velocity = new Vector3(xSpeed, 0, 0);
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
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			grapplingHook.stop();
			GameManager.Instance.Restart();
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(!dead) {
			if(other.transform.tag == "Wall") {
				grapplingHook.stop();
			}
		}
	}
}
