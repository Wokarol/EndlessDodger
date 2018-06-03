using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.RoadSystem {
	[ExecuteInEditMode]
	public class RoadSetter : MonoBehaviour {

		[SerializeField] float roadsWidth;
		[SerializeField] int roadCount;
		[SerializeField] Vector3 origin;
		[SerializeField] bool debug;

		void Update () {
			Road.CalculateRoads(roadsWidth/roadCount, roadCount, origin);

			if (debug) {
				for (int i = 0; i < Road.RoadCount; i++) {
					var roadStarting = Road.GetRoad(i);
					Debug.DrawRay(roadStarting, Vector3.up * 20);
				}
				for (int i = 0; i < Road.MidroadCount; i++) {
					var midRoadStrating = Road.GetMidroad(i);
					Debug.DrawRay(midRoadStrating, Vector3.up * 20, Color.blue);
				}

				Debug.DrawRay(Road.LeftEdge, Vector3.up * 20, Color.green);
				Debug.DrawRay(Road.RightEdge, Vector3.up * 20, Color.red);
			}
		}
	}
}