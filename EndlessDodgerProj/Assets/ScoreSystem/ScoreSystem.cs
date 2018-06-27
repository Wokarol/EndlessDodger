using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.ScoreSystem {
	[CreateAssetMenu]
	public class ScoreSystem : ScriptableObject {
		public int Score { get; private set; }

		public void SetScore (int value)
		{
			Score = value;
		}

		public void AddPoints(int value) {
			Score += value;
		}

	}
}