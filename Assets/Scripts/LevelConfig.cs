using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class LevelConfig : ScriptableObject
{	
	public Vector2Int dimensions;
	public MatchRule rule;
	
	[Range(3, 12)]
	public int fruitTypes;
}
