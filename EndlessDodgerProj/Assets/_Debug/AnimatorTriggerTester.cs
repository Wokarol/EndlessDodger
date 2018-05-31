using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerTester : MonoBehaviour {

	[SerializeField] string trigger0;
	[SerializeField] string trigger1;
	[SerializeField] string trigger2;
	[SerializeField] string trigger3;
	[SerializeField] string trigger4;
	[Space]
	[SerializeField] Animator anim;

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) { anim.SetTrigger(trigger0); }
		if (Input.GetKeyDown(KeyCode.Alpha2)) { anim.SetTrigger(trigger1); }
		if (Input.GetKeyDown(KeyCode.Alpha3)) { anim.SetTrigger(trigger2); }
		if (Input.GetKeyDown(KeyCode.Alpha4)) { anim.SetTrigger(trigger3); }
		if (Input.GetKeyDown(KeyCode.Alpha5)) { anim.SetTrigger(trigger4); }
	}

}
