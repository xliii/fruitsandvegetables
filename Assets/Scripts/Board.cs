using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	private HintProvider hintProvider;
	
	private void Awake()
	{
		The.Board = this;
		hintProvider = new HintProvider(this);		
	}

	public void Clear()
	{		
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
	}

	public Fruit Get(int index)
	{		
		var cell = transform.GetChild(index).GetComponent<Cell>();
		return cell.Fruit;		
	}

	public Fruit Get(Vector2Int pos)
	{
		return Get(pos.x, pos.y);
	}

	public Fruit Get(int x, int y)
	{
		if (x < 0 || x >= The.Width || y < 0 || y >= The.Height) return null;

		return Get(y * The.Width + x);
	}

	public bool OutOfBounds(Vector2Int pos)
	{
		//1 cell out of the board is ok, 2 is not
		var oob = pos.x < -1 || pos.x > The.Width || pos.y < -1 || pos.y > The.Height;
		if (oob)
		{
			Debug.Log("OutOfBounds: " + pos);
		}

		return oob;
	}

	public void GetHint()
	{
		var hint = hintProvider.getHint();
		Debug.Log("HINT: " + hint.AsString());
	}
}
