using UnityEngine;
using System.Collections;

public class BirdOnTrigger : MonoBehaviour {
	
	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Obstacle") {
			gameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Obstacle") {
			gameOver();
		}
	}

	private void gameOver () {
		gameController.isGameOver = true;
		gameController.FadeInGameOverImg ();
		gameController.pauseResumePanel.SetActive(false);
		GameController.repositionCount = 0;
	}
}
