using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.RoadSystem {
	public static class Road {
		public static float RoadWidth { get; private set; }
		public static int RoadCount { get; private set; }

		public static int MidroadCount { get { return RoadCount - 1; } }

		static Vector3[] roads;
		static Vector3[] midRoads;

		public static Vector3 LeftEdge { get; private set; }
		public static Vector3 RightEdge { get; private set; }

		public static void CalculateRoads (float _roadWidth, int _roadCount, Vector3 _origin) {
			RoadWidth = _roadWidth;
			RoadCount = _roadCount;

			roads = new Vector3[_roadCount];
			for (int i = 0; i < _roadCount; i++) {
				float _i = 0;
				if(_roadCount%2 == 0) {
					_i = i-(_roadCount/2)+0.5f;
				} else {
					_i = (i - (_roadCount - 1) / 2);
				}
				roads[i] = _origin + new Vector3(_roadWidth * _i, 0, 0);
			}
			midRoads = new Vector3[MidroadCount];
			for (int i = 0; i < MidroadCount; i++) {
				float _i = 0;
				if (MidroadCount % 2 == 0) {
					_i = i - (MidroadCount / 2) + 0.5f;
				} else {
					_i = (i - (MidroadCount - 1) / 2);
				}

				midRoads[i] = _origin + new Vector3(_roadWidth * _i, 0, 0);
			}

			float modifier = _roadCount / 2f;
			LeftEdge = _origin + new Vector3(-_roadWidth * modifier, 0, 0);
			RightEdge = _origin + new Vector3(_roadWidth * modifier, 0, 0);
		}

		internal static Vector3 GetRoad (int index) {
			if(index < roads.Length) {
				return roads[index];
			}
			throw new Exception("There is no read with that index");
		}
		internal static Vector3 GetMidroad (int index) {
			if (index < midRoads.Length) {
				return midRoads[index];
			}
			throw new Exception("There is no read with that index");
		}
	}
}