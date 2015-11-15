using UnityEngine;
using System.Collections;

public class RepositionTrigger : MonoBehaviour {
	
	public RepositionPipes ground1Pipes;
	public RepositionPipes ground2Pipes;
	public GameObject ground1PipesObj;
	public GameObject ground2PipesObj;

	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Ground") {
			Vector2 pos = new Vector2(gameController.groundWidth, other.gameObject.transform.position.y);
			other.gameObject.transform.position = pos;

			if (GameController.repositionCount < gameController.showPipesCount) {
				GameController.repositionCount++;
				if (GameController.repositionCount == (gameController.showPipesCount - 1)) {
					ground1PipesObj.SetActive(true);
				} else if (GameController.repositionCount == gameController.showPipesCount) {
					ground2PipesObj.SetActive(true);
				}
				return;
			}
			if (other.gameObject.name == "lv1_ground1") {
				ground1Pipes.ShowAndRepositionPipes();
			} else if (other.gameObject.name == "lv1_ground2") {
				ground2Pipes.ShowAndRepositionPipes();
			}
		}
	}

}
