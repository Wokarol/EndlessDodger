using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class RoadShower : MonoBehaviour {
		[SerializeField] bool show = true;
		[Space]
		[SerializeField] RoadSystem.Road road;
		[SerializeField] Color color = Color.white;

		private void OnDrawGizmosSelected ()
		{
			if (!road || !show) {
				return;
			}
			for (int i = 0; i < road.RoadwaysCount; i++) {
				var XPos = road.Roadways[i];
				Debug.DrawRay(new Vector3(XPos, -10), Vector3.up * 1000, color);
			}
		}
	}
}