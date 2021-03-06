﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class OnTrigger : MonoBehaviour {
		[SerializeField] bool watching = true;
		[SerializeField] bool debugData = false;
		[Space]
		[SerializeField] string lookedTag = "Enemy";
		[SerializeField] UnityEvent onTouch;

		private void OnTriggerEnter2D (Collider2D collider) {
			if (!watching) {
				return;
			}
			if(debugData) Debug.Log(gameObject.name + " touched " + collider.gameObject.tag);
			if (collider.gameObject.tag == lookedTag) {
				onTouch.Invoke();
			}
		}

	}
}