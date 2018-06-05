using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Follower : MonoBehaviour {
		[SerializeField] Transform target;
		[System.Serializable]
		struct FollowAxises {
			public bool x;
			public bool y;
			public bool z;

			public FollowAxises (bool x, bool y, bool z) {
				this.x = x;
				this.y = y;
				this.z = z;
			}
		}
		[SerializeField] FollowAxises followAxises = new FollowAxises(true, true, true);
		Vector3 offSet;

		private void Start () {
			offSet = transform.position - target.position;
		}

		private void LateUpdate () {
			Vector3 pos = transform.position;
			if (followAxises.x) {
				pos.x = target.position.x + offSet.x;
			}
			if (followAxises.y) {
				pos.y = target.position.y + offSet.y;
			}
			if (followAxises.z) {
				pos.z = target.position.z + offSet.z;
			}


			transform.position = pos;
		}
	}
}