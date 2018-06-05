using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.ScoreSystem {
	public class ScoreTrigger : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		ScoreSystem scoreSystem;
		Transform player;

		[SerializeField] int value;
		bool canScore;

		private void OnEnable () {
			poolObject.OnActivate += OnActivate;
		}

		void Start () {
			scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
		void OnActivate () {
			canScore = true;
		}

		void Update () {
			if (canScore && player.position.y > transform.position.y) {
				scoreSystem.AddPoints(value);
				canScore = false;
			}
		}
	}
}