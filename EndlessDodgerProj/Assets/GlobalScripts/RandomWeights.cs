using UnityEngine;

namespace Wokarol
{
	[System.Serializable]
	public class RandomWeights
	{
		[SerializeField] [Range(0,1)] float[] weights;
		float[] Weighs { get { return weights; } }

		public RandomWeights (int weightsCount)
		{
			weights = new float[weightsCount];
			for (int i = 0; i < weightsCount; i++) {
				weights[i] = 1f / weightsCount;
			}
		}

		public RandomWeights (float[] _weights)
		{
			weights = _weights;
			Normalize();
		}

		public void ChangeChance (int index, float value)
		{
			weights[index] += value;
			Normalize();
		}

		public int GetRandom ()
		{
			float randomFloat = Random.Range(0f, 1f);
			float lastRange = 0;

			for (int i = 0; i < weights.Length; i++) {
				if(randomFloat < (lastRange + weights[i])) {
					return i;
				} else {
					lastRange += weights[i];
				}
			}
			throw new System.Exception("There is problem with algoritm");
		}

		public int GetLowest ()
		{
			int currentLowestIndex = -1;
			float currentLowestChance = 20;

			for (int i = 0; i < weights.Length; i++) {
				if(weights[i] < currentLowestChance) {
					currentLowestChance = weights[i];
					currentLowestIndex = i;
				}
			}

			if(currentLowestIndex == -1) {
				throw new System.Exception("There is problem with algoritm");
			}
			return currentLowestIndex;
		}

		void Normalize ()
		{
			float total = 0;
			for (int i = 0; i < weights.Length; i++) {
				total += weights[i];
			}
			for (int i = 0; i < weights.Length; i++) {
				weights[i] /= total;
			}
		}
	}
}