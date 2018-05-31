#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour {
	[SerializeField] int maxFPS;


	private void Awake () {
		Application.targetFrameRate = maxFPS;
	}
}
#endif
