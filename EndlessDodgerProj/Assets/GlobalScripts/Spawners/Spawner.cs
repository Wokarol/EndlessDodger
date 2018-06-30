using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class Spawner : MonoBehaviour {

		[SerializeField] PoolSystem.PoolObjectIdentificator[] negativePrefabs;
		[SerializeField] PoolSystem.PoolObjectIdentificator[] positivePrefabs;
		[SerializeField] [Range(0,1)] float positivePrefabChance;

		[Space]
		[SerializeField] float time = 0.5f;
		[Space]
		[SerializeField] RoadSystem.Road road;
		[SerializeField] float yOffset;
		[Space]
		[SerializeField] IntVariableReference ObservedObjectRoadway;


		// REMOVE_DEBUG: Deserialize
		[SerializeField][Range(0,1)] float[] percentPerRoadway;

		PoolSystem.PoolManager poolManager;
		private float countdown;

		private void Start () {
			poolManager = PoolSystem.PoolManager.Instance;
			countdown = 0;
			percentPerRoadway = new float[road.RoadwaysCount];
			for (int i = 0; i < percentPerRoadway.Length; i++) {
				percentPerRoadway[i] = 1f / percentPerRoadway.Length;
			}
		}

		private void Update ()
		{
			RecalculatePercentage();
			Spawning();

			// REMOVE_DEBUG:
			float sum = 0;
			for (int i = 0; i < percentPerRoadway.Length; i++) {
				sum += percentPerRoadway[i];
			}
			//Debug.Log("<b>Sum </b>" + sum);
		}

		private void RecalculatePercentage ()
		{
			ChangeChance(ObservedObjectRoadway.Value, 0.001f);
		}

		private void ChangeChance(int index, float value)
		{
			percentPerRoadway[index] += value;
			float total = 0;
			for (int i = 0; i < percentPerRoadway.Length; i++) {
				total += percentPerRoadway[i];
			}
			for (int i = 0; i < percentPerRoadway.Length; i++) {
				percentPerRoadway[i] /= total;
			}
		}

		private void Spawning ()
		{
			if (countdown < 0) {

				bool positive = (Random.Range(0f, 1f) < positivePrefabChance);

				if (positive) {
					int prefabIndex = Random.Range(0, positivePrefabs.Length);
					int roadwayIndex = GetLowestChanceIndex(percentPerRoadway);

					poolManager.Spawn(positivePrefabs[prefabIndex],
						new Vector3(road.Roadways[roadwayIndex], yOffset + transform.position.y, 0),
						Quaternion.identity);

					// Change chance based on randomizated road for positive outcome
					ChangeChance(roadwayIndex, 0.2f);
				} else {
					int prefabIndex = Random.Range(0, negativePrefabs.Length);
					int roadwayIndex = GetIndexBasedOnHighestChanges(percentPerRoadway);

					poolManager.Spawn(negativePrefabs[prefabIndex], 
						new Vector3(road.Roadways[roadwayIndex], yOffset + transform.position.y, 0), 
						Quaternion.identity);

					// Change chance based on randomizated road for negative outcome
					ChangeChance(roadwayIndex, -0.005f);
				}
				countdown = time;
			}
			countdown -= Time.deltaTime;
		}

		public int GetIndexBasedOnHighestChanges (float[] chancesPack)
		{
			float randomFloat = Random.Range(0f, 1f);

			float lastRange = 0;

			for (int i = 0; i < chancesPack.Length; i++) {
				if(randomFloat < (lastRange + chancesPack[i])) {
					// This is getted int
					//Debug.Log("Getted " + i + " with lastA = " + lastA);
					return i;
				} else {
					lastRange += chancesPack[i];
				}
			}

			//Debug.LogError("What the hell?");
			return 0;
		}

		public int GetLowestChanceIndex (float[] chancesPack)
		{
			int currentLowestIndex = -1;
			float currenLowestChance = 20;

			for (int i = 0; i < chancesPack.Length; i++) {
				if(chancesPack[i] < currenLowestChance) {
					currenLowestChance = chancesPack[i];
					currentLowestIndex = i;
				}
			}

			return currentLowestIndex;
		}



#if UNITY_EDITOR
		private void OnDrawGizmos () {
			Debug.DrawLine(new Vector3(-4, yOffset, 0) + transform.position, new Vector3(4, yOffset, 0) + transform.position);
		}
		#endif
	}
}