using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorSelection", menuName = "Selection/Color", order = 1)]
public class ColorSelection : Selection
{
	public Color selectionColor;

	private Color defaultColor;

	public override void Init(Config config)
	{
		var cell = config.cellPrefab.GetComponent<Image>();
		defaultColor = cell.color;		
	}

	public override IEnumerator Select(Fruit fruit)
	{
		var cell = fruit.transform.parent.GetComponent<Image>();
		cell.color = selectionColor;
		yield break;		
	}

	public override IEnumerator Deselect(Fruit fruit)
	{
		var cell = fruit.transform.parent.GetComponent<Image>();
		cell.color = defaultColor;
		yield break;
	}
}
