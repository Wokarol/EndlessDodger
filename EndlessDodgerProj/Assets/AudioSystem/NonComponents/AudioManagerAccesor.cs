using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.AudioSystem {
	[CreateAssetMenu(menuName = "Audio/AudioAccesor")]
	public class AudioManagerAccesor : ScriptableObject {
		public AudioManager manager;

		// Passed functions
		public void PlayAudioSource(ClipIdentifier identifier) {
			if (IsNull())
				return;
			manager.PlayAudioSource(identifier);
		}


		// Null checker function
		bool IsNull ()
		{
			var isNull = manager == null;
			if (isNull)
				Debug.LogError("There is no manager assigned to this accesor");
			return isNull;
		}
	}
}