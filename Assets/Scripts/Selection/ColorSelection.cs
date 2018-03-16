using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSelection", menuName = "Selection/Color", order = 1)]
public class ColorSelection : Selection
{
	public Color selectionColor;
	
	public override IEnumerator Select(Fruit fruit)
	{
		fruit.button.targetGraphic.color = selectionColor;
		yield break;		
	}

	public override IEnumerator Deselect(Fruit fruit)
	{
		fruit.button.targetGraphic.color = Color.white;
		yield break;
	}
}
