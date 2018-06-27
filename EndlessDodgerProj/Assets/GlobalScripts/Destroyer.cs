using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Destroyer : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		[SerializeField] FloatVariableReference PlayerY;

		void Update () {
			if (PlayerY.Value - 5 > transform.position.y) {
				if (poolObject) {
					poolObject.Destroy();
				} else {
					Destroy(gameObject);
				}
			}
		}
	}
}