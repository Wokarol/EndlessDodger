using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {

	[RequireComponent(typeof(Animator))]
	public class GameOverController : MonoBehaviour {
		Animator anim;

		void Start () {
			anim = GetComponent<Animator>();
		}
		
		void Update () {
			
		}

		internal void GameOver () {
			anim.SetTrigger("GameOver");
		}
	}
}