﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	[System.Serializable]
	public class FloatVariableReference : GenericVariableReference<float, FloatVariable> {
	}

	[System.Serializable]
	public class StringVariableReference : GenericVariableReference<string, StringVariable> {
	}
}