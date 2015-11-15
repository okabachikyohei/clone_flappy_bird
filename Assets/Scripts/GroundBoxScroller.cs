using UnityEngine;
using System.Collections;

public class GroundBoxScroller : MonoBehaviour {

	public float scrollSpeed;

	void FixedUpdate () {
//		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
		transform.position = transform.position + Vector3.left * Time.fixedDeltaTime * scrollSpeed;
	}

}
