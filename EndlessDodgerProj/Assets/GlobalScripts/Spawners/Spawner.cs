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

		RandomWeights percentPerRoadway;

		PoolSystem.PoolManager poolManager;
		private float countdown;

		private void Start () {
			poolManager = PoolSystem.PoolManager.Instance;
			countdown = 0;
			percentPerRoadway = new RandomWeights(road.RoadwaysCount);
		}

		private void Update ()
		{
			RecalculatePercentage();
			Spawning();
		}

		private void RecalculatePercentage ()
		{
			percentPerRoadway.ChangeChance(ObservedObjectRoadway.Value, 0.001f);
		}


		private void Spawning ()
		{
			if (countdown < 0) {

				bool positive = (Random.Range(0f, 1f) < positivePrefabChance);

				if (positive) {
					int prefabIndex = Random.Range(0, positivePrefabs.Length);
					int roadwayIndex = percentPerRoadway.GetLowest();

					poolManager.Spawn(positivePrefabs[prefabIndex],
						new Vector3(road.Roadways[roadwayIndex], yOffset + transform.position.y, 0),
						Quaternion.identity);

					// Change chance based on randomizated road for positive outcome
					percentPerRoadway.ChangeChance(roadwayIndex, 0.2f);
				} else {
					int prefabIndex = Random.Range(0, negativePrefabs.Length);
					int roadwayIndex = percentPerRoadway.GetRandom();

					poolManager.Spawn(negativePrefabs[prefabIndex], 
						new Vector3(road.Roadways[roadwayIndex], yOffset + transform.position.y, 0), 
						Quaternion.identity);

					// Change chance based on randomizated road for negative outcome
					percentPerRoadway.ChangeChance(roadwayIndex, -0.005f);
				}
				countdown = time;
			}
			countdown -= Time.deltaTime;
		}



#if UNITY_EDITOR
		private void OnDrawGizmos () {
			Debug.DrawLine(new Vector3(-4, yOffset, 0) + transform.position, new Vector3(4, yOffset, 0) + transform.position);
		}
		#endif
	}
}