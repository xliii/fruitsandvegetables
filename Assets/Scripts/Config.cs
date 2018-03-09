using UnityEngine;

public class Config : MonoBehaviour
{	
	public MatchRule rule;	
	public Vector2Int dimensions;	
	public RectTransform boardContainer;
	public Board board;

	[HideInInspector]
	public int seed;
	
	public Cell cellPrefab;

	void Awake()
	{
		if (rule == null)
		{
			Debug.LogError("MatchRule should be set in Config");
			return;
		}
		
		The.Config = this;
		The.MatchRule = rule;
	}
	
	public bool validSize()
	{
		return Even(dimensions.x) || Even(dimensions.y);
	}
	
	bool Even(float number)
	{
		return (int) number % 2 == 0;
	}		

	private int offset = 5;
	private int cellSize = 55;
	
	public void Generate()
	{
		board.Clear();
		Debug.Log("Generate board: " + dimensions.x + "x" + dimensions.y);
		setContainerSize(dimensions.x, dimensions.y);
		int size = dimensions.x * dimensions.y;
		var fruits = The.Generator.GetRandomFruits(size);
		for (int i = 0; i < size; i++)
		{
			var cell = Instantiate(cellPrefab, board.transform);
			var fruit = Instantiate(fruits[i]);
			cell.Fruit = fruit;
		}
	}

	void setContainerSize(int x, int y)
	{
		boardContainer.sizeDelta = new Vector2Int(offset + x * cellSize, offset + y * cellSize);
	}
}
