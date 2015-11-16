using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {

	public Button okButton;

	public void InteractOkButton () {
		okButton.interactable = true;
	}
}
