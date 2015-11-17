using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Button pause;
	public Button resume;
	public Button newBtn;

	public GameObject player;
	public GameObject ground;
	public Rigidbody2D rb2D;

	public float force = 5f;
	public float gravityScale = 1f;

	public bool isGameStarted;
	public bool isGameOver;
	public bool isGamePaused;
	public float groundWidth;
	public SpriteRenderer sr;

	public static int repositionCount = 0;
	public int showPipesCount = 1;
	public static int gamePoint = 0;
	public static int highestPoint = 0;
	
	public GameObject pauseResumePanel;
	public GameObject gameOverPanel;
	public GameObject resultPanel;
	public GameObject pointPanel;
	public GameObject screenPanel;
	public Text pointText;
	public Text medalPointText;
	public Text highestPointText;
	
	public PerlinShake perlinShake;

	public Animator startGameAnim;
	private Animator gameOverAnim;
	private Animator birdAnim;

	private CanvasGroup newBtnCanvasGroup;

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
		isGamePaused = false;
		rb2D.gravityScale = 0f;
		sr = ground.GetComponent<SpriteRenderer> ();
		groundWidth = sr.bounds.size.x;
		gameOverAnim = gameOverPanel.GetComponent<Animator> ();
		birdAnim = player.GetComponent<Animator> ();
		newBtnCanvasGroup = newBtn.GetComponent<CanvasGroup> ();
	}

	public void OnPauseClicked() {
		isGamePaused = true;
		resume.gameObject.SetActive (true);
		pause.gameObject.SetActive (false);
		screenPanel.SetActive (true);
		newBtnCanvasGroup.alpha = 1;
		newBtnCanvasGroup.interactable = true;
		Time.timeScale = 0;
	}

	public void OnResumeClicked() {
		isGamePaused = false;
		resume.gameObject.SetActive (false);
		pause.gameObject.SetActive (true);
		screenPanel.SetActive (false);
		newBtnCanvasGroup.alpha = 0;
		newBtnCanvasGroup.interactable = false;
		Time.timeScale = 1;
	}

	public void OnOkClicked () {
		FadeManager.Instance.LoadLevel ("Open", 0.3f);
	}

	public void OnMenuClicked () {
//		screenPanel.SetActive (false);
//		FadeManager.Instance.LoadLevel ("Open", 0.3f);
	}

	public void GameOver () {
		isGameOver = true;
		perlinShake.PlayShake ();
		player.transform.rotation = Quaternion.Euler (0.0f, 0.0f, -90f);
		birdAnim.SetTrigger ("PlayerDead");
		gameOverAnim.SetTrigger ("ShowGameOver");
	}

	public void AddPoint () {
		gamePoint++;
		pointText.text = gamePoint.ToString ("0");
	}
	
	public void SetVaulesAfterGameOverAnimation() {
		pauseResumePanel.SetActive(false);
		pointPanel.SetActive (false);
		repositionCount = 0;
		medalPointText.text = gamePoint.ToString ("0");
		highestPoint = gamePoint >= highestPoint ? gamePoint : highestPoint;
		highestPointText.text = highestPoint.ToString ("0");
		gamePoint = 0;
	}
	
}
