using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class GameOverOnTouch : MonoBehaviour {

		string lookedTag = "Enemy";

		GameOverController gameOverController;

		private void Start () {
			gameOverController = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<GameOverController>();
		}

		private void OnCollisionEnter2D (Collision2D collision) {
			Debug.Log(collision.gameObject.tag);
			if (collision.gameObject.tag == lookedTag) {
				Time.timeScale = 0;
				gameOverController.GameOver();
			}
		}

	}
}