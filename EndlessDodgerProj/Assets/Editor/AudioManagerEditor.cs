using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor {

	AudioClip clipToAdd;

	public override void OnInspectorGUI () {
		AudioManager audioManager = target as AudioManager;

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Clip to add: ");
		clipToAdd = (AudioClip) EditorGUILayout.ObjectField(clipToAdd, typeof(AudioClip), false);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		audioManager.testSoundName = EditorGUILayout.TextField("Sounds name", audioManager.testSoundName);
		audioManager.testPitchMod = EditorGUILayout.FloatField("Sounds pitch mod", audioManager.testPitchMod);

		if(clipToAdd != null) {
			audioManager.AddSound(clipToAdd);
			clipToAdd = null;
		}

		if(GUILayout.Button("Test sound")) {
			audioManager.TestSound(audioManager.testSoundName, audioManager.testPitchMod);
		}
		if(GUILayout.Button("Delete test")) {
			DestroyImmediate(audioManager.testGo);
		}

		EditorGUILayout.Space();
		base.OnInspectorGUI();
	}

}
