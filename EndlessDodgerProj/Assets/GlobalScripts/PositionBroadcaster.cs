using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class PositionBroadcaster : MonoBehaviour
	{
		[SerializeField] FloatVariable x;
		[SerializeField] FloatVariable y;

		private void Update ()
		{
			var pos = transform.position;
			if (x)
				x.Value = pos.x;
			if (y)
				y.Value = pos.y;
		}
	}
}