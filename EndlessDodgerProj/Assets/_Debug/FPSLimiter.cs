#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour {
	[SerializeField] int maxFPS;


	private void Awake () {
		Debug.Log("Limited framerate to " + maxFPS);
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = maxFPS;
	}
}
#endif
