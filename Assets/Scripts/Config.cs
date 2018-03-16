using UnityEngine;

public class Config : MonoBehaviour
{

	public Selection selection;
	public LevelConfig levelConfig;
	public RectTransform boardContainer;
	public Board board;

	[HideInInspector]
	public int seed;
	
	public Cell cellPrefab;

	void Awake()
	{
		if (levelConfig == null)
		{
			Debug.LogError("LevelConfig should be set in Config");
			return;
		}
		
		The.Config = this;
	}
	
	public bool validSize()
	{
		return Even(The.Width) || Even(The.Height);
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
		Debug.Log("Generate board: " + The.Width + "x" + The.Height);
		setContainerSize(The.Width, The.Height);
		int size = The.Width * The.Height;
		var fruits = The.Generator.GetRandomFruits(size, levelConfig.fruitTypes);
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
