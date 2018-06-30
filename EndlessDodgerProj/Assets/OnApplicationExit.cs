using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class OnApplicationExit : MonoBehaviour {
		[SerializeField] UnityEvent exitEvent;

		private void OnApplicationQuit ()
		{
			exitEvent.Invoke();
		}
	}
}