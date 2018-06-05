using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.ScoreSystem {
	public class ScoreSystem : MonoBehaviour {
		public int Score { get; private set; }

		private void Start () {
			Score = 0;
		}

		public void AddPoints(int value) {
			Score += value;
		}

	}
}