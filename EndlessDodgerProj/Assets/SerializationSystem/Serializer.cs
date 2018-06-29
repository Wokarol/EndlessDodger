using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace Wokarol {
	[CreateAssetMenu]
	public class Serializer : ScriptableObject {
		// Consts
		private const string fileExtension = ".sav";
		private const string tempFileExtension = "_temp.sav";

		private const string debugPrefix = "<b>Serializer: </b>";

		// Values changed by user
		public string folderName = "Saves";
		public string fileName = "Save";

		// -----
		public Action OnSave;
		public Action OnLoad;

		Dictionary<string, object> currentData;

		// Calling Save and Load

		/// <summary>
		/// Initializes Save process
		/// </summary>
		public void Save ()
		{
			OnSave?.Invoke();
			SerializeData(currentData);
			Debug.Log(debugPrefix + "Saved " + currentData.Count + " entries to " + Path.Combine(Application.persistentDataPath, folderName) + " to " + fileName + fileExtension);

		}

		/// <summary>
		/// Initializes Load process
		/// </summary>
		public void Load ()
		{
			currentData = DeserializeData();
			OnLoad?.Invoke();
			Debug.Log(debugPrefix + "Loaded " + currentData.Count + " entries from " + Path.Combine(Application.persistentDataPath, folderName) + " from " + fileName + fileExtension);
		}

		// Private serialization methods

		/// <summary>
		/// Serializes data to file
		/// </summary>
		/// <param name="dataToSerialize">Data that is meant to be serialized</param>
		private void SerializeData(Dictionary<string, object> dataToSerialize)
		{
			var bf = new BinaryFormatter();
			string path = Path.Combine(Application.persistentDataPath, folderName);

			// Checking and creating path
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, folderName));
			}

			// Making stream out of data
			var stream = new FileStream(Path.Combine(path, fileName + tempFileExtension), FileMode.Create);
			bf.Serialize(stream, dataToSerialize);
			stream.Close();

			// Moving data from _temp.sav to .sav
			File.Delete(Path.Combine(path, fileName + fileExtension));
			File.Copy(Path.Combine(path, fileName + tempFileExtension), Path.Combine(path, fileName + fileExtension));
			File.Delete(Path.Combine(path, fileName + tempFileExtension));
		}

		/// <summary>
		/// Deserializes data from file
		/// </summary>
		/// <returns>Deserialized data</returns>
		private Dictionary<string, object> DeserializeData ()
		{
			var deserializationData = new Dictionary<string, object>();
			string path = Path.Combine(Application.persistentDataPath, folderName);

			if (File.Exists(Path.Combine(path, fileName + fileExtension))) {
				Debug.Log(debugPrefix + "Deserializing data");
				var bf = new BinaryFormatter();
				var stream = new FileStream(Path.Combine(path, fileName + fileExtension), FileMode.Open);
				deserializationData = (Dictionary<string, object>)bf.Deserialize(stream);
				stream.Close();
			}

			return deserializationData;
		}


		// Entry managing

		/// <summary>
		/// Sends entry to current data dictionary
		/// </summary>
		/// <param name="key">"Name" of the entry</param>
		/// <param name="value">Value</param>
		public void SendEntry (string key, object value)
		{
			if (currentData == null)
				Load();

			if (currentData.ContainsKey(key)) {
				currentData[key] = value;
			} else {
				currentData.Add(key, value);
			}
		}

		/// <summary>
		/// Gets entry from current data dictionary
		/// </summary>
		/// <typeparam name="T">Type of the value stored in entry</typeparam>
		/// <param name="key">"Name" of the entry</param>
		/// <param name="defaultValue">Value used when entry doesn't exist</param>
		/// <returns>Returned value</returns>
		public T GetEntry<T> (string key, T defaultValue)
		{
			if (currentData == null)
				Load();

			if (currentData.ContainsKey(key)) {
				if(currentData[key] is T) {
					return (T)currentData[key];
				}
			}
			SendEntry(key, defaultValue);
			return defaultValue;
		}

	}
}