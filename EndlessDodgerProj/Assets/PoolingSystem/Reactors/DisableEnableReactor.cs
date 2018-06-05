using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class DisableEnableReactor : MonoBehaviour {
		[SerializeField] PoolObject poolObject;
		[SerializeField] GameObject[] objects;
		[SerializeField] MonoBehaviour[] components;

		private void OnEnable () {
			poolObject.OnActivate += OnActivate;
			poolObject.OnDeactivate += OnDeactivate;
			poolObject.OnDestroy += OnDeactivate;
		}

		void OnActivate () {
			for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(true);
				//Debug.Log("<color=green>Setting " + objects[i].name + " to true</color>");
			}
			for (int i = 0; i < components.Length; i++) {
				components[i].enabled = true;
				//Debug.Log("<color=green>Setting " + components[i].name + " to true</color>");
			}
		}

		void OnDeactivate () {
			for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(false);
				//Debug.Log("<color=red>Setting " + objects[i].name + " to false</color>");
			}
			for (int i = 0; i < components.Length; i++) {
				components[i].enabled = false;
				//Debug.Log("<color=red>Setting " + components[i].name + " to false</color>");
			}
		}

	}
}