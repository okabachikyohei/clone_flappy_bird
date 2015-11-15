using UnityEngine;
using System.Collections;

public class GroundBoxScroller : MonoBehaviour {

	public float scrollSpeed;

	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	void FixedUpdate () {
//		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
		if (gameController.isGameOver)
			return;

		transform.position = transform.position + Vector3.left * Time.fixedDeltaTime * scrollSpeed;
	}

}
