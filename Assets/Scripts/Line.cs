using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	[SerializeField]
	private LineRenderer line;

	public float cellSize = 1.1f;

	public Color color;

	void Awake()
	{
		The.Line = this;
		line.material.SetColor("_TintColor", color);
		Clear();
	}

	public void Draw(List<Vector2Int> path)
	{
		line.positionCount = path.Count;
		for (var i = 0; i < path.Count; i++)
		{
			line.SetPosition(i, MapPos(path[i]));
		}
	}

	public void Clear()
	{
		line.positionCount = 0;
	}

	private Vector3 MapPos(Vector2Int pos)
	{
		var offsetX = The.Width / 2;
		var offsetY = The.Height / 2;
		var baseX = The.Width % 2 == 0 ? cellSize / 2 : 0;
		var baseY = The.Height % 2 == 0 ? cellSize / 2 : 0;
		var x = baseX + (pos.x - offsetX) * cellSize;
		var y = baseY + (pos.y - offsetY) * cellSize;
		return new Vector3(x, -y, 0);
	}
}
