using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wokarol {
	[CreateAssetMenu]
	public class Serializer : ScriptableObject {
		public string fileName;

		public System.Action OnSave;
		public System.Action OnLoad;

		Dictionary<string, object> currentData = new Dictionary<string, object>();

		// Calling Save and Load

		public void Save ()
		{
			OnSave?.Invoke();
			SerializeData(currentData);
			Debug.Log("Saved " + currentData.Count + " entries");

		}

		public void Load ()
		{

		}

		// Private serialization methods

		private void SerializeData(Dictionary<string, object> dataToSerialize)
		{

		}

		private Dictionary<string, object> DeserializeData ()
		{
			// TODO: yeah
			return null;
		}


		// Entry managing

		public void SendEntry (string key, object value)
		{

		}

		public T GetEntry<T> (string key, T defaultValue)
		{
			// TODO: yeah
			return defaultValue;
		}

	}
}