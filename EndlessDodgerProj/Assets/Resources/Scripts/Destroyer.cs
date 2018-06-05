using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Destroyer : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		Transform player;

		private void Start () {
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}

		void Update () {
			if (player.position.y - 5 > transform.position.y) {
				poolObject.Destroy();
			}
		}
	}
}