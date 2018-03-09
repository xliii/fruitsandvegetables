using UnityEngine;

public static class Vector2IntExtensions {

	public static Vector2Int Left(this Vector2Int pos)
	{
		return new Vector2Int(pos.x - 1, pos.y);
	}
	
	public static Vector2Int Right(this Vector2Int pos)
	{
		return new Vector2Int(pos.x + 1, pos.y);
	}
	
	public static Vector2Int Up(this Vector2Int pos)
	{
		return new Vector2Int(pos.x, pos.y - 1);
	}
	
	public static Vector2Int Down(this Vector2Int pos)
	{
		return new Vector2Int(pos.x, pos.y + 1);
	}
}
