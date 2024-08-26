using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Satze {
	private string _satzeFullString;
	private Vector2 _satzeOrigin;
	private Effect _satzeEffect;

	public Satze(string satzeFullString) {
		_satzeFullString = satzeFullString;
		_satzeOrigin = Vector2.zero;
	}

	public bool ParseSatzeString() {
		_satzeOrigin = Vector2.zero;
		List<string> splitString = _satzeFullString.Split(' ').ToList();
		
		Vector2? direction = Direction.DetermineDirection(splitString);
		if (direction == null) {
			return false;
		}
		if (splitString == null) {
			throw new Exception("INVALID SATZE");
		}

		splitString = determineSatzeEffect(splitString);
		handleModifiers(splitString);
		
		Debug.Log("Effect: Flame");
		Debug.Log("Damage: " + _satzeEffect.Damage);
		Debug.Log("Radius: " + _satzeEffect.Radius);
		Debug.Log("Location: " + _satzeOrigin);
	}

	private List<string> determineSatzeEffect(List<string> splitString) {
		switch (splitString.Last().ToUpper()) {
			case ""
		}
		splitString.RemoveAt(splitString.Count - 1);
		return splitString;
	}

	private void handleModifiers(List<string> splitString) {
		foreach (string s in splitString) {
			// Hard-coded enhance
			_satzeEffect.Enhance();
		}
	}
}
