using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed = 0.5f;

	Vector3 startPosition;
	Renderer bgRenderer;
	GameController gameController;
	
	void Start () {
		bgRenderer = GetComponent<Renderer> ();
		gameController = GameController.Instance ();
	}

	void Update () {
		if (gameController.isGameOver)
			return;

		Vector2 offset = new Vector2 (Time.time * scrollSpeed , 0.0f);
		bgRenderer.material.mainTextureOffset = offset;
	}
}
