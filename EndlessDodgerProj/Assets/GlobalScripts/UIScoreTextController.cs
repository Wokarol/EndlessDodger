using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wokarol.ScoreSystem {
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class UIScoreTextController : MonoBehaviour {
		TextMeshProUGUI textMesh;
		ScoreSystem scoreSystem;
		void OnEnable () {
			scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
			textMesh = GetComponent<TextMeshProUGUI>();
		}
		
		void Update () {
			textMesh.text = scoreSystem.Score.ToString();
		}
	}
}