using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class KeyEvents : MonoBehaviour {

		[SerializeField] KeyCode key = KeyCode.F11;
		[SerializeField] UnityEvent onKeyDown;

		void Update () {
			if (Input.GetKeyDown(key)) {
				onKeyDown.Invoke();
			}
		}
	}
}