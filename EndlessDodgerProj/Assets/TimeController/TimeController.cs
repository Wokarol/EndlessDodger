using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	[CreateAssetMenu]
	public class TimeController : ScriptableObject {
		[SerializeField] float baseFixedDeltaTime = 0.02f;

		public void SetScale(float scale) {
			Time.timeScale = scale;
			Time.fixedDeltaTime = baseFixedDeltaTime * scale;
		}
	}
}