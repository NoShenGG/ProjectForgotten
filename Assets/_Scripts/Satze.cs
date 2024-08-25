using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Satze {
	private string _satzeFullString;
	private Vector2 _satzeOrigin;
	private Flame _satzeEffect;

	public Satze(string satzeFullString) {
		_satzeFullString = satzeFullString;
		_satzeOrigin = Vector2.zero;
	}

	public void ParseSatzeString() {
		_satzeOrigin = Vector2.zero;
		List<string> splitString = _satzeFullString.Split(' ').ToList();
		splitString = determineDirection(splitString);
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

	private List<string> determineDirection(List<string> splitString) {
		int directionWeight = 2;
		while (directionWeight >= 0) {
			switch (splitString.Last().ToUpper()) {
				case "FORWARD":
					_satzeOrigin += Vector2.right;
					directionWeight--;
					break;
				case "BACK":
					_satzeOrigin += Vector2.left;
					directionWeight--;
					break;
				case "UP":
					_satzeOrigin += Vector2.up;
					directionWeight--;
					break;
				case "DOWN":
					_satzeOrigin += Vector2.down;
					directionWeight--;
					break;
				default:
					if (directionWeight == 2) {
						return null;
					}
					return splitString;
			}

			splitString.RemoveAt(splitString.Count - 1);
		}

		return splitString;
	}

	private List<string> determineSatzeEffect(List<string> splitString) {
		// Hard-coded flame
		_satzeEffect = new Flame();
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
