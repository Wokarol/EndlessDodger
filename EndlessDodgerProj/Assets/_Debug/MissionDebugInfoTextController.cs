using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MissionDebugInfoTextController : MonoBehaviour {
	TextMeshProUGUI textMesh;
	[TextArea]
	[SerializeField] string text = "";

	private void Start () {
		textMesh = GetComponent<TextMeshProUGUI>();
		textMesh.text = text;
	}

	void OnEnable () {
		Application.logMessageReceived += HandleLog;
	}
	void OnDisable () {
		Application.logMessageReceived -= HandleLog;
	}
	void HandleLog (string logString, string stackTrace, LogType type) {
		if (logString.StartsWith("<color=teal>-> </color>" )) {
			string textToShow = logString.Replace("<color=teal>-> </color>", "");
			text += "\n";
			text += textToShow;

			textMesh.text = text;
		}

		if(logString.StartsWith("<color=red>->")) {
			string textToShow = logString.Replace("->", "");
			text += "\n";
			text += textToShow;

			textMesh.text = text;
		}
	}
}
