using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour {

	[SerializeField] float timeScale;

	private void Awake () {
		Time.timeScale = timeScale;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}
}
