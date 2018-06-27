using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class SpawnerByDistance : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObjectIdentificator prefabIdentificator;
		[SerializeField] GameObject preSpawnPrefab;
		[SerializeField] Vector3 offset;
		[SerializeField] float distance;
		[Space]
		[SerializeField] int preSpawnOnStart;

		float lastY;

		PoolSystem.PoolManager poolManager;

		private void Start () {
			poolManager = PoolSystem.PoolManager.Instance;

			Vector3 pos = (transform.position + offset);
			lastY = pos.y;

			poolManager.Spawn(prefabIdentificator, pos, Quaternion.identity);

			for (int i = 0; i < preSpawnOnStart; i++) {
				Vector3 newPos = pos;
				newPos.y -= distance * (i + 1);
				Instantiate(preSpawnPrefab, newPos, Quaternion.identity);
			}
		}

		private void Update () {
			Vector3 pos = (transform.position + offset);
			if (lastY + distance < pos.y) {
				lastY += distance;
				Vector3 spawnPos = pos;
				spawnPos.y = lastY;
				poolManager.Spawn(prefabIdentificator, spawnPos, Quaternion.identity);
			}
		}

		private void OnDrawGizmos () {
			Gizmos.DrawWireSphere(offset + transform.position, 0.5f);
			Gizmos.DrawLine(offset + transform.position, offset + transform.position + Vector3.up * distance);
		}
	}
}