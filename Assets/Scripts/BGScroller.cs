using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed = 0.5f;

	Vector3 startPosition;
	Renderer bgRenderer;
	GameController gameController;

	// Use this for initialization
	void Start () {
		bgRenderer = GetComponent<Renderer> ();
		gameController = GameController.Instance ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.isGameOver)
			return;

		Vector2 offset = new Vector2 (Time.time * scrollSpeed , 0.0f);
		bgRenderer.material.mainTextureOffset = offset;
	}
}
