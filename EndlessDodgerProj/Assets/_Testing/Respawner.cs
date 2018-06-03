using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wokarol.RoadSystem;

namespace Wokarol {
	public class Respawner : MonoBehaviour {
		[SerializeField] bool midroadSpawn;
		void Update () {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Vector3 startPoint;
				if (midroadSpawn) {
					startPoint = Road.GetMidroad(Random.Range(0, Road.MidroadCount)) + Vector3.up*12;
				} else {
					startPoint = Road.GetRoad(Random.Range(0, Road.RoadCount)) + Vector3.up * 12;
				}
				transform.position = startPoint;
			}
		}
	}
}