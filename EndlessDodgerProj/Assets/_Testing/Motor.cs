using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Motor : MonoBehaviour {
		[SerializeField] float speed;

		void FixedUpdate () {
			transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
		}
	}
}