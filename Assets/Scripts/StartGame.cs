using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public void Play () {
		FadeManager.Instance.LoadLevel ("Main", 0.3f);
	}
}
