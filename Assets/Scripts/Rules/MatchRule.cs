using System.Collections;
using UnityEngine;

public abstract class MatchRule : ScriptableObject
{
	public abstract bool CanMatch(Fruit a, Fruit b);

	public abstract IEnumerator Match(Fruit a, Fruit b);
}
