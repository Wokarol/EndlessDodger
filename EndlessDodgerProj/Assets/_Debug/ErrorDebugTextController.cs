using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ErrorDebugTextController : MonoBehaviour {
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
		if (type == LogType.Error || type == LogType.Exception) {
			string textToShow = logString.Replace("<color=teal>", "<color=#008080>");
			text += "\n";
			text += textToShow;

			textMesh.text = text;
		}
	}
}
