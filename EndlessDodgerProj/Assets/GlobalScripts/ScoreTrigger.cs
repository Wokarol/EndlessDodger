using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.ScoreSystem {
	public class ScoreTrigger : MonoBehaviour {
		ScoreSystem scoreSystem;

		void Start () {
			scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
		}

		public void SendScore (int value)
		{
			scoreSystem.AddPoints(value);
		}
	}
}