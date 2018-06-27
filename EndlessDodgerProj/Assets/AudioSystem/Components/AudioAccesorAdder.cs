using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.AudioSystem {
	[RequireComponent(typeof(AudioManager))]
	public class AudioAccesorAdder : MonoBehaviour {
		// Accesor to add manager to
		[SerializeField] AudioManagerAccesor accesor;

		// Manager to add
		AudioManager manager;
		private void Awake ()
		{
			manager = GetComponent<AudioManager>();
			accesor.manager = manager;
		}
	}
}