using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Direction {
	private static int _maxDirectionWeight = 2;
	private enum DirectionType {
		Forward,
		Back,
		Up,
		Down,
		Self
	}
	
	public static Vector2? DetermineDirection(List<string> splitString, out List<string> modifiedSplitString) {
		int directionWeight = _maxDirectionWeight;
		Vector2 direction = Vector2.zero;
		while (directionWeight >= 0) {
			bool validDirection = Enum.TryParse(splitString.Last(), out DirectionType nextDirection);
			if (!validDirection) {
				if (directionWeight == _maxDirectionWeight) {
					modifiedSplitString = null;
					return null;
				} else {
					modifiedSplitString = splitString;
					return direction;
				}
			}
			switch (nextDirection) {
				case DirectionType.Forward:
					direction += Vector2.right;
					directionWeight--;
					break;
				case DirectionType.Back:
					direction += Vector2.left;
					directionWeight--;
					break;
				case DirectionType.Up:
					direction += Vector2.up;
					directionWeight--;
					break;
				case DirectionType.Down:
					direction += Vector2.down;
					directionWeight--;
					break;
				case DirectionType.Self:
					direction += Vector2.zero;
					directionWeight -= 2;
					break;
			}

			if (directionWeight < 0) {
				return null;
			}
			directions.RemoveAt(0);
		}

		return direction.normalized;
	}
}