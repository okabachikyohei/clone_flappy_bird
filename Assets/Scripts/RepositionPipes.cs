using UnityEngine;
using System.Collections;

public class RepositionPipes : MonoBehaviour {

	public float maxHeight = 0.7f;
	public float minHeight = -1f;
	public GameObject pipes1;
	public GameObject pipes2;

	public float distanceBetween;

	public void ShowAndRepositionPipes() {
		float pipes1PosY = Random.Range (minHeight, maxHeight);
		Vector2 pipes1Pos = new Vector2 (pipes1.gameObject.transform.position.x, pipes1PosY);
		pipes1.gameObject.transform.position = pipes1Pos;
		Vector2 pipes2Pos = new Vector2 (pipes2.gameObject.transform.position.x, Random.Range(minHeight, maxHeight));
		pipes2.gameObject.transform.position = pipes2Pos; 
	}
}
