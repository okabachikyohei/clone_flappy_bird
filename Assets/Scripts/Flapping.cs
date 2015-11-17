﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Flapping : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float rotateSpeed;
	public float maxFallSpeed;

	private Rigidbody2D rb2D;
	private GameController gameController;
	private Animator startGameAnim;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		gameController = GameController.Instance ();
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (!CanvasButtonClicked()) {
				if (!gameController.isGameStarted) {
					gameController.isGameStarted = true;
					gameController.startGameAnim.SetTrigger("FadeOutGameStartPanel");
					rb2D.gravityScale = gameController.gravityScale;
				}
				rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
			}
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

	private bool CanvasButtonClicked()
	{
		UnityEngine.EventSystems.EventSystem ct
			= UnityEngine.EventSystems.EventSystem.current;
		
		if (! ct.IsPointerOverGameObject() ) 
			return false;
		if (! ct.currentSelectedGameObject ) 
			return false;
		if (ct.currentSelectedGameObject.GetComponent<Button>() == null )
			return false;
		
		return true;
	}
}
