using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class ClickingCatcher : MonoBehaviour {
		[SerializeField] PlayerController playerController;

		private void Update () {
			if (Input.GetMouseButtonDown(0)) {
				if(Input.mousePosition.x < (Screen.width/2)) {
					// Clicked left half on screen
					playerController.Turn(-1);
				} else {
					// Clicked right half on screen
					playerController.Turn(1);
				}
			}
		}
	}
}