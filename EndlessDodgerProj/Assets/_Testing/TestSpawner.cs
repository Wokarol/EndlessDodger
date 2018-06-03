﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class TestSpawner : MonoBehaviour {

		[SerializeField] GameObject prefab;
		[Space]
		[SerializeField] RoadSystem.Road road;
		[SerializeField] float yOffset;

		private void Start () {
			StartCoroutine(Spawning());
		}

		private IEnumerator Spawning () {
			while (true) {
				Instantiate(prefab, new Vector3(road.Roadways[Random.Range(0, road.RoadwaysCount)] , yOffset, 0) + transform.position, Quaternion.identity);
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