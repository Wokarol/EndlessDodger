using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfoController : MonoBehaviour {

	[SerializeField] CanvasGroup[] objectsToHide;
	[SerializeField] bool showState = true;

	bool lastFramePressed = false;
	private void Start () {
		for (int i = 0; i < objectsToHide.Length; i++) {
			objectsToHide[i].alpha = (showState) ? 1 : 0;
		}
	}

	private void Update () {
		if(Input.touchCount == 3 || Input.GetKey(KeyCode.F9)) {
			if (!lastFramePressed) {
				Debug.Log("<color=teal>DIC:</color> pressed and reacted beacuse lastFramePressed is " + lastFramePressed);
				showState = !showState;
				for (int i = 0; i < objectsToHide.Length; i++) {
					objectsToHide[i].alpha = (showState) ? 1 : 0;
				}
				lastFramePressed = true;
			}
		} else {
			lastFramePressed = false;
		}
	}

}
