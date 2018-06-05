using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class StartAnimReactor : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		[Space]
		[SerializeField] Animator animator;
		[SerializeField] string trigger;
		int triggerHash;

		private void OnEnable () {
			poolObject.OnActivate += OnActivate;
		}

		private void Start () {
			triggerHash =  Animator.StringToHash(trigger);
		}

		void OnActivate () {
			animator.SetTrigger(triggerHash);
		}
	}
}