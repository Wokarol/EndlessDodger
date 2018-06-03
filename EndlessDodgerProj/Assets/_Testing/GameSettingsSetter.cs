using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	[ExecuteInEditMode]
	public class GameSettingsSetter : MonoBehaviour {
		[SerializeField] float speed;
		private void Update () {
			GameSettings.Speed = speed;
		}
	}
}