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

	// Handling logs and diplaying them if there're errors or exceptions
	void HandleLog (string logString, string stackTrace, LogType type) {
		if (type == LogType.Error || type == LogType.Exception) {
			// Changing every <color=teal> to <color=#008080>
			while (logString.Contains("<color=teal>")) {
				logString = logString.Replace("<color=teal>", "<color=#008080>");
			}
			// Adding log as new line
			text += "\n";
			text += logString;

			textMesh.text = text;
		}
	}
}
