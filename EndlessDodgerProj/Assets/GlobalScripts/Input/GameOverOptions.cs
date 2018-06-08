using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wokarol {
	public class GameOverOptions : MonoBehaviour {
		private void Start () {
			Time.timeScale = 1;
		}

		public void LoadLevel (string lvlName) {
			SceneManager.LoadScene(lvlName);
		}

	}
}