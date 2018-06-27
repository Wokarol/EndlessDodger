using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.RoadSystem {
	[CreateAssetMenu]
	public class Road : ScriptableObject {
		public int RoadwaysCount { get { return Roadways.Length; } }
		public readonly float[] Roadways = {-2, -1, 0, 1, 2};
	}
}