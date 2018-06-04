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
			}
			for (int i = 0; i < components.Length; i++) {
				components[i].enabled = true;
			}
		}

		void OnDeactivate () {
			for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(false);
			}
			for (int i = 0; i < components.Length; i++) {
				components[i].enabled = false;
			}
		}

	}
}