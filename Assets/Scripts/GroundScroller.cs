using UnityEngine;
using System.Collections;

public class GroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeY;

	void Start () {

	}

	void FixedUpdate () {
//		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
		transform.position = transform.position + Vector3.left * Time.fixedDeltaTime * scrollSpeed;
	}

}
