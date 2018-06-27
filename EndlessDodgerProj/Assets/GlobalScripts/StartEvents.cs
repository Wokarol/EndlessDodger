using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class StartEvents : MonoBehaviour {

		[SerializeField] UnityEvent startEvent;

		void Start () {
			startEvent.Invoke();
		}
	}
}