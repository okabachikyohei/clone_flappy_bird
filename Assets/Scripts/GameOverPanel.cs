using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {

	public Button okButton;
	GameController gameController;

	void Start() {
		gameController = GameController.Instance ();
	}

	public void InteractOkButton () {
		okButton.interactable = true;
		gameController.SetVaulesAfterGameOverAnimation ();
		GameController.gamePoint = 0;
	}
}
