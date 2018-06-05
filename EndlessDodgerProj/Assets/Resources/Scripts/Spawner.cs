using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Spawner : MonoBehaviour {

		[SerializeField] PoolSystem.PoolObjectIdentificator[] prefabs;
		[SerializeField] float time = 0.5f;
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
				poolManager.Spawn(prefabs[Random.Range(0, prefabs.Length)], new Vector3(road.Roadways[Random.Range(0, road.RoadwaysCount)], yOffset + transform.position.y, 0), Quaternion.identity);
				yield return new WaitForSeconds(time);
			}
		}

		#if UNITY_EDITOR
		private void OnDrawGizmos () {
			Debug.DrawLine(new Vector3(-4, yOffset, 0) + transform.position, new Vector3(4, yOffset, 0) + transform.position);
		}
		#endif
	}
}