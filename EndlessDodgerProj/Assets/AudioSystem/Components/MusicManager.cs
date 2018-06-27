using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Every change to public functions needs to be reflected in MusicManagerAccesor!

namespace Wokarol.AudioSystem
{
	[AddComponentMenu("Audio/MusicManager")]
	public class MusicManager : MonoBehaviour
	{


		[SerializeField] MusicPack musicPack;
		[Space]
		[SerializeField] UnityEngine.Audio.AudioMixerGroup mixerGroup;
		[Header("Events")]
		[SerializeField] UnityEvent beforeMusicChange;
		[SerializeField] UnityEvent onMusicChange;

		int currentTrackIndex = -1;

		AudioSource[] musicSources;
		int currentSourceIndex;

		Coroutine smoothCoroutine;

		private void Start ()
		{
			InitializeSources();
			FindNewTrack();
		}

		/// <summary>
		/// Finds new random track from current pack
		/// </summary>
		[ContextMenu("Find new random track")]
		public void FindNewTrack ()
		{
			int newRandomTrackIndex = Random.Range(0, musicPack.musicTracks.Length);
			while (newRandomTrackIndex == currentTrackIndex) {
				newRandomTrackIndex = (newRandomTrackIndex + 1) % musicPack.musicTracks.Length;
			}

			currentTrackIndex = newRandomTrackIndex;
			PlayTrack(musicPack.musicTracks[newRandomTrackIndex], 2);
		}

		public void PlayTrack (AudioClip newTrack, float timeToChange)
		{
			beforeMusicChange.Invoke();

			if(smoothCoroutine != null) {
				StopCoroutine(smoothCoroutine);
			}
			smoothCoroutine = StartCoroutine(PlayTrackSmoth(newTrack, timeToChange));
		}

		public IEnumerator PlayTrackSmoth (AudioClip newTrack, float timeToChange)
		{
			// Setting before changing
			var newSourceIndex = (currentSourceIndex + 1) % musicSources.Length;

			AudioSource currentSource = musicSources[currentSourceIndex];
			AudioSource newSource = musicSources[newSourceIndex];


			currentSource.volume = 1;
			newSource.volume = 0;
			newSource.clip = newTrack;

			if (!newSource.isPlaying) {
				newSource.Play();
			}
			if (!currentSource.isPlaying) {
				currentSource.Play();
			}

			// Logic for FadeIn and FadeOut
			float progress = 0;
			while (progress < 1) {
				yield return null;

				var deltaTime = Time.deltaTime/timeToChange;
				newSource.volume += deltaTime;
				currentSource.volume -= deltaTime;
				progress += deltaTime;
			}


			// Setting everything after

			currentSource.volume = 0;
			newSource.volume = 1;

			if (!newSource.isPlaying) {
				newSource.Play();
			}
			currentSource.Stop();

			currentSourceIndex = newSourceIndex;

			onMusicChange.Invoke();
		}


		// Initialize two audio sources for music manager to use
		public void InitializeSources ()
		{
			musicSources = new AudioSource[2];

			var childCount = transform.childCount;
			for (int i = 0; i < childCount; i++) {
				Destroy(transform.GetChild(i).gameObject);
			}

			for (int i = 0; i < 2; i++) {
				var _ob = new GameObject("Music Source " + i);
				_ob.transform.parent = transform;
				var _aSource = _ob.AddComponent<AudioSource>();
				_aSource.outputAudioMixerGroup = mixerGroup;
				_aSource.loop = true;

				//_aSource.playOnAwake = false;

				musicSources[i] = _aSource;
			}

		}

	}
}