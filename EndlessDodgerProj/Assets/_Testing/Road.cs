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

		public int MidroadwaysCount {
			get {
				return roadwaysCount - 1;
			}
		}


		public float[] Roadways { get; private set; }
		public float[] Midroadways { get; private set; }

		public float LeftEdge { get; private set; }
		public float RightEdge { get; private set; }

		private void Awake () {
			CreateRoad();
		}

		void CreateRoad () {
			Roadways = new float[roadwaysCount];
			// Generating roadways
			for (int i = 0; i < roadwaysCount; i++) {
				Roadways[i] = RoadwayWidth * (i - roadwaysCount / 2 + (1 - roadwaysCount % 2) * 0.5f) + transform.position.x;
			}
			// Generating midroadways
			Midroadways = new float[MidroadwaysCount];
			for (int i = 0; i < MidroadwaysCount; i++) {
				Midroadways[i] = (Roadways[i] + Roadways[i + 1]) / 2;
			}
			LeftEdge = (RoadwayWidth * -roadwaysCount / 2) + transform.position.x;
			RightEdge = (RoadwayWidth * roadwaysCount / 2) + transform.position.x;
		}

		private void OnDrawGizmos () {
			if (debug) {
				CreateRoad();
				for (int i = 0; i < roadwaysCount; i++) {
					Debug.DrawLine(new Vector3(Roadways[i], 10000, 0), new Vector3(Roadways[i], -10000, 0));
				}
				for (int i = 0; i < MidroadwaysCount; i++) {
					Debug.DrawLine(new Vector3(Midroadways[i], 10000, 0), new Vector3(Midroadways[i], -10000, 0), Color.grey);
				}

				Debug.DrawLine(new Vector3(LeftEdge, 10000, 0), new Vector3(LeftEdge, -10000, 0), Color.blue);
				Debug.DrawLine(new Vector3(RightEdge, 10000, 0), new Vector3(RightEdge, -10000, 0), Color.cyan);
			}
		}
	}
}