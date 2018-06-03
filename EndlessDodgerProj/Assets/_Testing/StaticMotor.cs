using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class StaticMotor : MonoBehaviour {
		void Update () {
			transform.Translate(Vector3.down * GameSettings.Speed * Time.deltaTime);
		}
	}
}