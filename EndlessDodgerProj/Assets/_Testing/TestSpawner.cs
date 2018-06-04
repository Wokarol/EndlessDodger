using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class TestSpawner : MonoBehaviour {

		[SerializeField] PoolSystem.PoolObjectIdentificator prefab;
		[Space]
		[SerializeField] RoadSystem.Road road;
		[SerializeField] float yOffset;

		PoolSystem.PoolManager poolManager;

		private void Start () {
			poolManager = PoolSystem.PoolManager.Instance;
			StartCoroutine(Spawning());
		}

		private IEnumerator Spawning () {
			while (true) {
				poolManager.Spawn(prefab, new Vector3(road.Roadways[Random.Range(0, road.RoadwaysCount)], yOffset + transform.position.y, 0), Quaternion.identity);
				yield return new WaitForSeconds(0.4f);
			}
		}

		#if UNITY_EDITOR
		private void OnDrawGizmos () {
			Debug.DrawLine(new Vector3(-4, yOffset, 0) + transform.position, new Vector3(4, yOffset, 0) + transform.position);
		}
		#endif
	}
}