using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.ScoreSystem {
	[CreateAssetMenu]
	public class ScoreSystem : ScriptableObject {

		[Tooltip("Serializer object that deserializes file containg highscore")]
		[SerializeField] Serializer HighscoreData;

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
			var prevHighscore = HighscoreData.GetEntry<int>(StringConsts.HIGHSCORE, 0);
			//var prevHighscore = PlayerPrefs.GetFloat(StringConsts.HIGHSCORE);

			if(Score > prevHighscore) {
				//PlayerPrefs.SetFloat(StringConsts.HIGHSCORE, Score);
				HighscoreData.SendEntry(StringConsts.HIGHSCORE, Score);
				OnHighscore.Invoke();
			}
		}

	}
}