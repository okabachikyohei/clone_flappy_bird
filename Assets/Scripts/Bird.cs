using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float force = 5f;
	public float upAndDownRange = 0.5f;
	public float upAndDownSpeed = 2.0f;
	public float gravityScale = 1f;

	Rigidbody2D rb2D;
	Vector2 velocity;
	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Update () {

	}

	void FixedUpdate() {
		if (!gameController.isGameStarted) {
			rb2D.MovePosition(transform.position + transform.up * (Mathf.PingPong (Time.time, upAndDownRange) - upAndDownRange / 2) * Time.fixedDeltaTime);
		}
	}
}
