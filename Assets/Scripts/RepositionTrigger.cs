using UnityEngine;
using System.Collections;

public class RepositionTrigger : MonoBehaviour {

	public GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			Vector2 pos = new Vector2(gameController.groundWidth, other.gameObject.transform.position.y);
//			other.gameObject.transform.position.x = gameController.groundWidth;
			other.gameObject.transform.position = pos;
		}
	}

}
