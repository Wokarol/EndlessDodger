using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wokarol.ScoreSystem {
	[RequireComponent(typeof(TextMeshPro))]
	public class ScoreTextController : MonoBehaviour {
		TextMeshPro textMesh;
		ScoreSystem scoreSystem;
		void OnEnable () {
			scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
			textMesh = GetComponent<TextMeshPro>();
		}
		
		void Update () {
			textMesh.text = scoreSystem.Score.ToString();
		}
	}
}