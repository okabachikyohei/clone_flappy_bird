using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Button pause;
	public Button resume;
	
	public GameObject ground;
	public Rigidbody2D rb2D;

	public float force = 5f;
	public float gravityScale = 1f;

	public bool isGameStarted;
	public bool isGameOver;
	public float groundWidth;
	public SpriteRenderer sr;

	public static int repositionCount = 0;
	public int showPipesCount = 1;

	public GameObject gameStartPanel;
	public GameObject pauseResumePanel;
	public GameObject gameOverPanel;
	public GameObject resultPanel;

	private Animator startGameAnim;
	private Animator gameOverAnim;

	private static GameController instance;

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
		isGameOver = false;
		rb2D.gravityScale = 0f;
		sr = ground.GetComponent<SpriteRenderer> ();
		groundWidth = sr.bounds.size.x;
		startGameAnim = gameStartPanel.GetComponent<Animator> ();
		gameOverAnim = gameOverPanel.GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (!isGameStarted) {
				isGameStarted = true;
				startGameAnim.SetTrigger("FadeOutGameStartPanel");
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

	public void FadeInGameOverImg() {
		gameOverAnim.SetTrigger ("ShowGameOver");
	}

	public void OnOkClicked () {
		FadeManager.Instance.LoadLevel ("Open", 0.3f);
	}

}
