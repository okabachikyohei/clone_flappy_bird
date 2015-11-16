using UnityEngine;
using System.Collections;

public class OpenSceneGroundScroller : MonoBehaviour {

	void FixedUpdate() {
		transform.position = new Vector3(-Mathf.Repeat(Time.time, 3.36f) * 2, transform.position.y, 0.0f);
	}
}
