using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class TestMovement : MonoBehaviour {
		[SerializeField] float speed;
		private void Update () {
			transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
		}
	}
}