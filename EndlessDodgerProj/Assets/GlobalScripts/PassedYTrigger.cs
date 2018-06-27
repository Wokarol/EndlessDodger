using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol {
	public class PassedYTrigger : MonoBehaviour {
		[SerializeField] FloatVariableReference y;
		[SerializeField] FloatVariableReference yThreshhold = new FloatVariableReference { UseConstant = true, ConstantValue = 5f };

		[SerializeField] UnityEvent onPassed;

		private void Update ()
		{
			if (y.Value - yThreshhold.Value > transform.position.y) {
				onPassed.Invoke();
			}
		}
	}
}