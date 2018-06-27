using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.AudioSystem
{
	[CreateAssetMenu(menuName = "Audio/MusicAccesor")]
	public class MusicManagerAccesor : ScriptableObject
	{
		public MusicManager manager;

		// Functions passers
		public void FindNewTrack ()
		{
			if (IsNull())
				return;
			manager.FindNewTrack();
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