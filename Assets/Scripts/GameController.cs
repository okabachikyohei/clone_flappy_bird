using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private static GameController instance;

	public Button pause;
	public Button resume;

	public GameObject readyObjs;
	public Rigidbody2D rb2D;

	public float force = 5f;
	public float gravityScale = 1f;

	public bool isGameStarted;

	public static GameController Instance() {
		if (!instance) {
			instance = FindObjectOfType(typeof(GameController)) as GameController;
			if (!instance) {
				Debug.LogError("GameController script needs to be attached to an object!");
			}
		}

		return instance;
	}
	
	void Start () {
		resume.gameObject.SetActive (false);
		isGameStarted = false;
		rb2D.gravityScale = 0f;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (!isGameStarted) {
				isGameStarted = true;
				readyObjs.SetActive(false);
				rb2D.gravityScale = gravityScale;
			}
		}
	}

	public void OnPauseClicked() {
		resume.gameObject.SetActive (true);
		pause.gameObject.SetActive (false);

		Time.timeScale = 0;
	}

	public void OnResumeClicked() {
		resume.gameObject.SetActive (false);
		pause.gameObject.SetActive (true);

		Time.timeScale = 1;
	}
}
