using UnityEngine;
using System.Collections;

public class OpenSceneBGScroller : MonoBehaviour {

	public float scrollSpeed = 0.5f;

	Vector3 startPosition;
	Renderer bgRenderer;

	// Use this for initialization
	void Start () {
		bgRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * scrollSpeed , 0.0f);
		bgRenderer.material.mainTextureOffset = offset;
	}
}
