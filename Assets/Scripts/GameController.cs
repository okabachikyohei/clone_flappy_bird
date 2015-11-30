using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Button pauseBtn;
	public Button resumeBtn;
	public Button menuBtn;

	public GameObject player;
	public GameObject ground;
	public Rigidbody2D rb2D;
	
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
	public Image medalImage;
	public Sprite medalNormal;
	public Sprite medalBronze;
	public Sprite medalSilver;
	public Sprite medalGold;
	public Image newBestImage;

	public PerlinShake perlinShake;

	public Animator startGameAnim;
	private Animator gameOverAnim;
	private Animator birdAnim;

	private CanvasGroup menuBtnCanvasGroup;

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
		resumeBtn.gameObject.SetActive (false);
		isGameStarted = false;
		isGameOver = false;
		isGamePaused = false;
		rb2D.gravityScale = 0f;
		sr = ground.GetComponent<SpriteRenderer> ();
		groundWidth = sr.bounds.size.x;
		gameOverAnim = gameOverPanel.GetComponent<Animator> ();
		birdAnim = player.GetComponent<Animator> ();
		menuBtnCanvasGroup = menuBtn.GetComponent<CanvasGroup> ();
	}

	public void OnPauseClicked() {
		isGamePaused = true;
		resumeBtn.gameObject.SetActive (true);
		pauseBtn.gameObject.SetActive (false);
//		menuBtn.gameObject.SetActive (true);
		screenPanel.SetActive (true);
		menuBtnCanvasGroup.alpha = 1;
		menuBtnCanvasGroup.interactable = true;
		Time.timeScale = 0;
	}

	public void OnResumeClicked() {
		isGamePaused = false;
		resumeBtn.gameObject.SetActive (false);
		pauseBtn.gameObject.SetActive (true);
//		menuBtn.gameObject.SetActive (false);
		screenPanel.SetActive (false);
		menuBtnCanvasGroup.alpha = 0;
		menuBtnCanvasGroup.interactable = false;
		Time.timeScale = 1;
	}

	public void OnOkClicked () {
		FadeManager.Instance.LoadLevel ("Open", 0.3f);
	}

	public void OnMenuClicked () {
		OnResumeClicked();
		FadeManager.Instance.LoadLevel ("Open", 0.3f);
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
		SetMedalImage ();
		repositionCount = 0;
		medalPointText.text = gamePoint.ToString ("0");
		if (gamePoint > highestPoint) {
			newBestImage.gameObject.SetActive(true);
		}
		highestPoint = gamePoint >= highestPoint ? gamePoint : highestPoint;
		highestPointText.text = highestPoint.ToString ("0");
		gamePoint = 0;
	}

	private void SetMedalImage() {
		if (gamePoint >= 10) {
			medalImage.gameObject.SetActive(true);
		}

		if (gamePoint >= 10 && gamePoint < 19) {
			medalImage.sprite = medalNormal;
		} else if (gamePoint >= 20 && gamePoint < 29) {
			medalImage.sprite = medalBronze;
		} else if (gamePoint >= 30 && gamePoint < 39) {
			medalImage.sprite = medalSilver;
		} else if (gamePoint >= 40) {
			medalImage.sprite = medalGold;
		}
	}
	
}
