using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.RoadSystem {
	public class Road : MonoBehaviour {
		[SerializeField] int roadwaysCount;
		[SerializeField] float roadWidth;

		[SerializeField] bool debug;

		public int RoadwaysCount {
			get {
				return roadwaysCount;
			}
		}
		public float RoadWidth {
			get {
				return roadWidth;
			}
		}
		public float RoadwayWidth { get { return RoadWidth / RoadwaysCount; } }


		public float[] Roadways { get; private set; }
		private void Start () {
			Roadways = new float[roadwaysCount];
			for (int i = 0; i < roadwaysCount; i++) {
				Roadways[i] = RoadwayWidth * (i - roadwaysCount/2 + (1-roadwaysCount%2)*0.5f);
			}
		}



		private void LateUpdate () {
			if (debug) {
				for (int i = 0; i < roadwaysCount; i++) {
					Debug.DrawLine(new Vector3(Roadways[i], 10000, 0), new Vector3(Roadways[i], -10000, 0));
				}
			}
		}
	}
}