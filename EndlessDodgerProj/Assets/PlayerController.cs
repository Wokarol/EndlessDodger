using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class PlayerController : MonoBehaviour {
		public delegate void TurnDelegate (int direction);
		public TurnDelegate OnTurn;

		private void Update () {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				OnTurn?.Invoke(-1);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				OnTurn?.Invoke(1);
			}
		}

	}
}