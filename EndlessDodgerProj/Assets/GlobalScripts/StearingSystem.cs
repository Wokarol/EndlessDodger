using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class StearingSystem : MonoBehaviour {
		[SerializeField] PlayerController playerController;
		[Space]
		[SerializeField] float speed;
		[SerializeField] AnimationCurve moveCurve;
		[SerializeField] AnimationCurve scaleCurve;
		[SerializeField] AnimationCurve rotCurve;
		[Space]
		[SerializeField] RoadSystem.Road road;
		[SerializeField] int startingRoadway;


		int currentRoadway = 0;
		[SerializeField] IntVariableReference CurrentRoadway;

		Coroutine TurnCoroutine;

		bool canMove;

		private void Start () {
			canMove = true;
			currentRoadway = Mathf.Clamp(startingRoadway, 0, road.RoadwaysCount - 1);
			CurrentRoadway.Value = currentRoadway;
			playerController.OnTurn += OnTurn;
		}

		public void OnTurn (int dir) {
			int newInd = currentRoadway + dir;
			newInd = Mathf.Clamp(newInd, 0, road.RoadwaysCount - 1);

			if (newInd != currentRoadway && canMove) {
				canMove = false;
				currentRoadway = newInd;
				if (TurnCoroutine != null) {
					StopCoroutine(TurnCoroutine);
				}
				TurnCoroutine = StartCoroutine(TurnAnim(GetNewPos(newInd), dir));
			}

			CurrentRoadway.Value = currentRoadway;
		}

		IEnumerator TurnAnim (float newPos, int dir) {
			float percent = 1;
			float oldPos = transform.position.x;

			while (percent > 0) {
				if(percent < 0.5f && !canMove) {
					canMove = true;
				}

				Vector3 pos = transform.position;
				pos.x = Mathf.LerpUnclamped(oldPos, newPos, moveCurve.Evaluate(1-percent));
				transform.position = pos;

				transform.localScale = Vector3.one * scaleCurve.Evaluate(1 - percent);

				transform.rotation = Quaternion.Euler(0, 0, rotCurve.Evaluate(1 - percent) * 360f * Mathf.Sign(dir));

				percent -= Time.deltaTime * speed;
				yield return null;
			}

			Vector3 endPos = transform.position;
			endPos.x = Mathf.Lerp(oldPos, newPos, 1);
			transform.position = endPos;
			transform.localScale = Vector3.one;
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		float GetNewPos(int ind) {
			ind = Mathf.Clamp(currentRoadway, 0, road.RoadwaysCount - 1);
			return road.Roadways[ind];
		}

	}
}