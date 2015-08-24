using UnityEngine;
using System.Collections;

public class ModifiersManager {

	public static int modifierLength;
	private IModifier[] modifier;

	public ModifiersManager()
	{
		modifierLength = 2;
		modifier = new IModifier[modifierLength];
	}

	public ModifiersManager(int _length)
	{
		modifierLength = _length;
		modifier = new IModifier[modifierLength];
	}

	public IModifier CheckModifier(int _position)
	{
		if (_position >= 0 && _position < modifierLength) {
			return modifier[_position];
		} else {
			return null;
		}
	}

	public IModifier SetModifier(IModifier _modifier, int _position)
	{
		if (_position >= 0 && _position < modifierLength) {
			IModifier oldModifier = modifier[_position];
			modifier[_position] = _modifier;
			return oldModifier;
		} else {
			return null;
		}
	}
}
