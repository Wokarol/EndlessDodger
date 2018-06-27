using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.AudioSystem {
	[RequireComponent(typeof(MusicManager))]
	public class MusicAccesorAdder : MonoBehaviour {
		// Accesor to add it to
		[SerializeField] MusicManagerAccesor accesor;

		// Manager to add
		MusicManager manager;

		private void Awake ()
		{
			manager = GetComponent<MusicManager>();
			accesor.manager = manager;
		}
	}
}