using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class OnCollision : MonoBehaviour {

		[SerializeField] string lookedTag = "Enemy";
		[SerializeField] UnityEvent onTouch;

		private void OnCollisionEnter2D (Collision2D collision) {
			Debug.Log(collision.gameObject.tag);
			if (collision.gameObject.tag == lookedTag) {
				onTouch.Invoke();
			}
		}

	}
}