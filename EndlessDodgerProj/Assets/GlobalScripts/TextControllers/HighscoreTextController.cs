﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class HighscoreTextController : MonoBehaviour {

		[Tooltip("Serializer object that deserializes file containg highscore")]
		[SerializeField] Serializer HighscoreData;
		[SerializeField] TMPro.TMP_Text text;

		public void UpdateText ()
		{
			text.text = HighscoreData.GetEntry<int>(StringConsts.HIGHSCORE, 0).ToString();
		}

		private void OnValidate ()
		{
			if (!text) {
				text = GetComponent<TMPro.TMP_Text>();
			}
		}
	}
}