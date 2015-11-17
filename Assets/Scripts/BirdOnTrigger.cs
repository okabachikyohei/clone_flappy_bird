using UnityEngine;
using System.Collections;

public class BirdOnTrigger : MonoBehaviour {
	
	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!gameController.isGameOver && other.gameObject.tag == "Obstacle") {
			gameController.GameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!gameController.isGameOver && other.gameObject.tag == "Obstacle") {
			gameController.GameOver();
		}

		if (other.gameObject.tag == "PointCollider" && gameController.isGameStarted) {
			gameController.AddPoint();
		}
	}
	
}
