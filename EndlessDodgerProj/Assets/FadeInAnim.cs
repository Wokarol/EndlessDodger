using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	[RequireComponent(typeof(CanvasGroup))]
	public class FadeInAnim : MonoBehaviour {
		CanvasGroup group;
		float progress;

		[Tooltip("Seconds nedded to fade in")]
		[SerializeField] float time = 1;

		private void Awake ()
		{
			group = GetComponent<CanvasGroup>();
			progress = 0;
		}

		private void Update ()
		{
			group.alpha = 1 - progress;
			progress = Mathf.Clamp01(progress += Time.deltaTime * (1/time));
		}

		private void OnValidate ()
		{
			progress = 0;
		}
	}
}