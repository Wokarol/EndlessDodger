using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class PoolManager : MonoBehaviour {
		[SerializeField] PoolObjectToAdd[] pools;
		Dictionary<PoolObjectIdentificator, int> nameToIndex = new Dictionary<PoolObjectIdentificator, int>();

			// Repair
		public static PoolManager Instance { get; private set; }
		private void Awake () {
			if(Instance != null) {
				Destroy(gameObject);
				return;
			}
			Instance = this;

			for (int i = 0; i < pools.Length; i++) {
				nameToIndex.Add(pools[i].prefab.objectName, i);

				for (int j = 0; j < pools[i].startCount; j++) {
					PoolObject _obj = Instantiate(pools[i].prefab, transform);
					_obj.Deactivate();
					pools[i].AddObject(_obj);
				}
			}
		}

		internal void RegisterDestroyed (PoolObjectIdentificator _name, PoolObject poolObject) {
			if (!nameToIndex.ContainsKey(_name)) {
				Debug.LogError("<color=red>There is no pool named " + _name + " in Dictionary</color>");
				return;
			}
			pools[nameToIndex[_name]].AddObject(poolObject);
		}

		public PoolObject Spawn(PoolObjectIdentificator _name, Vector3 pos, Quaternion rot) {
			if (!nameToIndex.ContainsKey(_name)) {
				Debug.LogError("<color=red>There is no pool named " + _name + " in Dictionary</color>");
				return null;
			}
			// Adding objects if queue is empty
			if(pools[nameToIndex[_name]].ObjectsToUse <= 0) {
				for (int j = 0; j < pools[nameToIndex[_name]].growBy; j++) {
					pools[nameToIndex[_name]].AddObject(Instantiate(pools[nameToIndex[_name]].prefab, transform));
				}
			}

			PoolObject _obj = pools[nameToIndex[_name]].GetObject();
			_obj.transform.SetPositionAndRotation(pos, rot);

			_obj.Activate(this);

			return _obj;
		}

	}

	[System.Serializable]
	class PoolObjectToAdd {
		[SerializeField] internal PoolObject prefab;
		[Space]
		[SerializeField] internal float startCount;
		[SerializeField] internal float growBy;

		Queue<PoolObject> objects = new Queue<PoolObject>();
		internal int ObjectsToUse { get; private set; } = 0;



		internal void AddObject(PoolObject _obj) {
			objects.Enqueue(_obj);
			ObjectsToUse++;
		}
		internal PoolObject GetObject () {
			ObjectsToUse--;
			return objects.Dequeue();
		}
	}
}
