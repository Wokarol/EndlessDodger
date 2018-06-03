using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Follower : MonoBehaviour {
		[SerializeField] Transform target;
		Vector3 offSet;

		private void Start () {
			offSet = transform.position - target.position;
		}

		private void LateUpdate () {
			transform.position = target.position + offSet;
		}
	}
}