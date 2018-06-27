using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Every change to public functions needs to be reflected in MusicManagerAccesor!

namespace Wokarol.AudioSystem
{
	[AddComponentMenu("Audio/Manager")]
	public class AudioManager : MonoBehaviour
	{
		Dictionary<ClipIdentifier, AudioSource> audioSourcesDictionary = new Dictionary<ClipIdentifier, AudioSource>();
		[SerializeField] List<AudioSourceReference> audioSources = new List<AudioSourceReference>();

		private void Awake ()
		{
			for (int i = 0; i < audioSources.Count; i++) {
				var audioSourceRef = audioSources[i];
				if (!audioSourcesDictionary.ContainsKey(audioSourceRef.Identifier)) {
					if (audioSourceRef.AudioSource != null) {
						audioSourcesDictionary.Add(audioSourceRef.Identifier, audioSourceRef.AudioSource);
					}
				}
			}
		}

		public void PlayAudioSource (ClipIdentifier identifier)
		{
			if (audioSourcesDictionary.ContainsKey(identifier)) {
				audioSourcesDictionary[identifier].Play();
			}
		}
	}
}