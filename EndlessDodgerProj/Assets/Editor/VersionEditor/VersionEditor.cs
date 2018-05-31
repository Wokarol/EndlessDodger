using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class VersionEditor : EditorWindow , /*IPostprocessBuildWithReport,*/ IPreprocessBuildWithReport{

	// Core systems

	public struct VersionDataPack {
		public int major;
		public int minor;
		public int subMinor;
		public int build;

		public override bool Equals (object target) {
			VersionDataPack obj = (VersionDataPack)target;
			return (major == obj.major &&
				minor == obj.minor &&
				subMinor == obj.subMinor &&
				build == obj.build);
		}
		public static bool operator == (VersionDataPack obj1, VersionDataPack obj2) {
			return (obj2.major == obj1.major &&
				obj2.minor == obj1.minor &&
				obj2.subMinor == obj1.subMinor &&
				obj2.build == obj1.build);
		}
		public static bool operator != (VersionDataPack obj1, VersionDataPack obj2) {
			return !(obj2.major == obj1.major &&
				obj2.minor == obj1.minor &&
				obj2.subMinor == obj1.subMinor &&
				obj2.build == obj1.build);
		}
		public override int GetHashCode () {
			int hash = 13;
			hash = (hash * 7) + major.GetHashCode();
			hash = (hash * 7) + minor.GetHashCode();
			hash = (hash * 7) + subMinor.GetHashCode();
			hash = (hash * 7) + buildPrefix.GetHashCode();
			hash = (hash * 7) + build.GetHashCode();
			return hash;
		}
	}
	VersionDataPack versionData;
	const char buildPrefix = 'b';
	VersionDataPack lastVersionData;
	public void UpdateVersionInWindow () {
		lastVersionData = versionData;
	}
	[MenuItem("Tools/VersionEditor/Editor")]
	static void Init () {
		VersionEditor window = (VersionEditor)GetWindow(typeof(VersionEditor));
		window.Show();
	}

	public void OnGUI () {
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.HelpBox("Current version: " + Application.version, MessageType.None);
		IntSetter(ref versionData.major,"Major", ref versionData.minor, ref versionData.subMinor);
		IntSetter(ref versionData.minor,"Minor", ref versionData.subMinor);
		IntSetter(ref versionData.subMinor,"SubMinor");


		if (EditorPrefs.GetBool("VersionEditorSettings.BuildNumberEditor")) {
			IntSetter(ref versionData.build, "Build");
		} else {
			EditorGUILayout.HelpBox("Build: " + versionData.build, MessageType.None);
		}

		if (lastVersionData != versionData && GUILayout.Button("Accept")) {
			GUI.FocusControl("");
			SetVersion(versionData);
			UpdateVersionInWindow();
		}

		if (EditorGUI.EndChangeCheck()) {
			if (EditorPrefs.GetBool("VersionEditorSettings.AutoSetVersion")) {
				SetVersion(versionData);
				UpdateVersionInWindow();
			}
		}
	}

	public static void SetVersion (VersionDataPack versionData) {
		PlayerSettings.bundleVersion = versionData.major + "." + versionData.minor + "." + versionData.subMinor + buildPrefix + versionData.build;
	}
	void IntSetter (ref int value, string name, ref int prevValue0) {
		int trashInt = 0;
		IntSetter(ref value, name, ref prevValue0, ref trashInt);
	}
	void IntSetter (ref int value, string name) {
		int trashInt0 = 0;
		int trashInt1 = 0;
		IntSetter(ref value, name, ref trashInt0, ref trashInt1);
	}
	void IntSetter(ref int value, string name, ref int prevValue0, ref int prevValue1) {
		EditorGUILayout.BeginHorizontal();
		value = EditorGUILayout.IntField(name, value);
		if (GUILayout.Button("+")) {
			value++;
			if (EditorPrefs.GetBool("VersionEditorSettings.ResetPrev")) {
				prevValue0 = 0;
				prevValue1 = 0;
			}
			GUI.FocusControl("");
		}
		if (GUILayout.Button("-")) {
			value--;
			GUI.FocusControl("");
		}
		if (GUILayout.Button("0")) {
			value = 0;
			GUI.FocusControl("");
		}
		value = Mathf.Clamp(value, 0, int.MaxValue);
		EditorGUILayout.EndHorizontal();
	}

	private void OnEnable () {
		versionData = LoadEditorData();
		UpdateVersionInWindow();
	}

	// major.minor.subMinor[bPref]build
	public static VersionDataPack LoadEditorData () {
		string versionString = PlayerSettings.bundleVersion;
		VersionDataPack tempVersionData = new VersionDataPack();
		var numbers = versionString.Split('.');
		if(numbers.Length != 3) {
			return tempVersionData;
		}
		int value = 0;
		if(int.TryParse(numbers[0], out value)){
			tempVersionData.major = value;
		} else {
			tempVersionData.major = 0;
		}
		if (int.TryParse(numbers[1], out value)) {
			tempVersionData.minor = value;
		} else {
			tempVersionData.minor = 0;
		}

		var subMinorAndbuild = numbers[2].Split(buildPrefix);
		if (subMinorAndbuild.Length != 2) {
			return tempVersionData;
		}

		if (int.TryParse(subMinorAndbuild[0], out value)) {
			tempVersionData.subMinor = value;
		} else {
			tempVersionData.subMinor = 0;
		}
		if (int.TryParse(subMinorAndbuild[1], out value)) {
			tempVersionData.build = value;
		} else {
			tempVersionData.build = 0;
		}
		return tempVersionData;
	}

	public int callbackOrder { get { return 0 ; } }

	public void OnPostprocessBuild (BuildReport report) {
		if (EditorPrefs.GetBool("VersionEditorSettings.AutoIncrBuild")) {
			VersionDataPack tempVersionData = LoadEditorData();

			tempVersionData.build++;
			SetVersion(tempVersionData);
		}
		SetVersion(LoadEditorData());
		UpdateVersionInWindow();
	}

	public void OnPreprocessBuild (BuildReport report) {
		SetVersion(LoadEditorData());
		UpdateVersionInWindow();
	}
}

[InitializeOnLoad]
public class PlayModeHandler : Editor {

	static PlayModeHandler () {
		EditorApplication.playModeStateChanged += ModeChanged;
	}

	static void ModeChanged (PlayModeStateChange playModeState) {
		if (playModeState == PlayModeStateChange.EnteredEditMode) {
			VersionEditor.SetVersion(VersionEditor.LoadEditorData());
		}
		if (playModeState == PlayModeStateChange.ExitingEditMode) {
			if (EditorPrefs.GetBool("VersionEditorSettings.AutoIncrBuildByPlay")) {
				VersionEditor.VersionDataPack tempVersionData = VersionEditor.LoadEditorData();
				tempVersionData.build++;
				VersionEditor.SetVersion(tempVersionData);
				VersionEditor[] windows = FindObjectsOfType<VersionEditor>();
				foreach (VersionEditor editor in windows) {
					editor.UpdateVersionInWindow();
				}

			}
		}
	}

}
