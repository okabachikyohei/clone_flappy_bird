using UnityEngine;
using System.Collections;

public class Flapping : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float rotateSpeed;
	public float maxFallSpeed;

	private Rigidbody2D rb2D;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
		}

//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, -90f), Time.time * rotateSpeed);
//		transform.Rotate (0.0f, 0.0f, -rotateSpeed);
	}

	void FixedUpdate() {
		rb2D.velocity = new Vector2 (moveSpeed, rb2D.velocity.y);
		if (rb2D.velocity.y <= -maxFallSpeed) {
			rb2D.velocity = new Vector2(rb2D.velocity.x, -maxFallSpeed);
		}
	}
}
