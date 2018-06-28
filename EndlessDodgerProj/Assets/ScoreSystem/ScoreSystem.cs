using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.ScoreSystem {
	[CreateAssetMenu]
	public class ScoreSystem : ScriptableObject {
		public int Score { get; private set; }
		public UnityEvent OnHighscore;

		public void SetScore (int value)
		{
			Score = value;
		}

		public void AddPoints(int value) {
			Score += value;
		}

		public void CountHighscore ()
		{
			var prevHighscore = PlayerPrefs.GetFloat(StringConsts.HIGHSCORE);
			if(Score > prevHighscore) {
				PlayerPrefs.SetFloat(StringConsts.HIGHSCORE, Score);
				OnHighscore.Invoke();
			}
		}

	}
}