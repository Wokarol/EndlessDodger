using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Follower : MonoBehaviour {
		[SerializeField] Transform target;
		[System.Serializable]
		struct FollowAxises {
			public float x;
			public float y;
			public float z;

			public FollowAxises (float x = 1, float y = 1, float z = 1) {
				this.x = x;
				this.y = y;
				this.z = z;
			}
		}
		[SerializeField] FollowAxises axises;

		Vector3 targetStart;
		Vector3 myStart;

		private void Start () {
			myStart = transform.position;
			targetStart = target.position;
		}

		private void LateUpdate () {
			var targetOffset = (target.position - targetStart);
			//var myOffset = (transform.position - myStart);
			var newOffset = targetOffset/* - myOffset*/;
			newOffset.x *= axises.x;
			newOffset.y *= axises.y;
			newOffset.z *= axises.z;

			transform.position = myStart + newOffset;

			//Debug.Log("target:" + targetOffset + "	 my:" + myOffset + "	offset:" + newOffset);
		}
	}
}