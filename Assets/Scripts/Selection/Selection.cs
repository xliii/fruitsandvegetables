using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selection : ScriptableObject
{
	public virtual void Init(Config config) {}

	public abstract IEnumerator Select(Fruit fruit);

	public abstract IEnumerator Deselect(Fruit fruit);
	
}
