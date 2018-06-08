using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Motor : MonoBehaviour {
		[SerializeField] float speed;
		[SerializeField] float acceleration;

		void FixedUpdate () {
			transform.Translate(transform.InverseTransformVector(Vector3.up) * speed * Time.fixedDeltaTime);
			speed += acceleration * Time.deltaTime;
		}
	}
}