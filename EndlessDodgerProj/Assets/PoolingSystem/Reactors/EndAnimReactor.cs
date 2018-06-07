using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class EndAnimReactor : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		[Space]
		[SerializeField] Animator animator;
		[SerializeField] string trigger;
		int triggerHash;

		private void OnEnable () {
			poolObject.OnDeactivate += OnDeactivate;
			poolObject.OnDestroy += OnDeactivate;
			triggerHash =  Animator.StringToHash(trigger);
		}

		void OnDeactivate () {
			animator.SetTrigger(triggerHash);
		}
	}
}