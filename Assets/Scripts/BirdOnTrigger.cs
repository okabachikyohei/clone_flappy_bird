using UnityEngine;
using System.Collections;

public class BirdOnTrigger : MonoBehaviour {

	Rigidbody2D rb2D;
	GameController gameController;

	void Start() {
		rb2D = GetComponent<Rigidbody2D> ();
		gameController = GameController.Instance ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Obstacle") {
			gameController.isGameOver = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Obstacle") {
			gameController.isGameOver = true;
		}
	}
}
