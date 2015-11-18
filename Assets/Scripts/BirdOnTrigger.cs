using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BirdOnTrigger : MonoBehaviour {

	public Image flashImage;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public float flashSpeed = 5f;

	private GameController gameController;
	private bool gotHit;

	void Start() {
		gameController = GameController.Instance ();
	}

	
	void Update ()
	{
		if(gotHit)
		{
			flashImage.color = flashColour;
		}
		
		else
		{
			flashImage.color = Color.Lerp (flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}		
		gotHit = false;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!gameController.isGameOver && other.gameObject.tag == "Obstacle") {
			gotHit = true;
			gameController.GameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!gameController.isGameOver && other.gameObject.tag == "Obstacle") {
			gotHit = true;
			gameController.GameOver();
		}

		if (other.gameObject.tag == "PointCollider" && gameController.isGameStarted) {
			gameController.AddPoint();
		}
	}
	
}
