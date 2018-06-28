using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class HighscoreTextController : MonoBehaviour {

		[SerializeField] TMPro.TMP_Text text;

		void Update () {
			text.text = PlayerPrefs.GetFloat(StringConsts.HIGHSCORE).ToString();
		}

		private void OnValidate ()
		{
			if (!text) {
				text = GetComponent<TMPro.TMP_Text>();
			}
		}
	}
}