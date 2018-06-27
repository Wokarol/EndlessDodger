using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Wokarol.AudioSystem {
	[CustomPropertyDrawer(typeof(AudioSourceReference))]
	public class AudioSourceReferencePropertyDrawer : PropertyDrawer {

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			// Start here

			// Rects

			var spacing = 20;
			var identifierWidth = position.width / 2;

			var identifierRect = new Rect(position.x, position.y, identifierWidth - spacing/2, position.height);
			var sourceRect = new Rect(position.x + identifierWidth + spacing/2, position.y, position.width - identifierWidth - spacing / 2, position.height);

			// Fields
			EditorGUI.PropertyField(identifierRect, property.FindPropertyRelative("Identifier"), GUIContent.none);
			EditorGUI.PropertyField(sourceRect, property.FindPropertyRelative("AudioSource"), GUIContent.none);

			// End lines
			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

	}
}