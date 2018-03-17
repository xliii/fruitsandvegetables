using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{

	[SerializeField]
	[HideInInspector]
	private Fruit _fruit;

	public Fruit Fruit
	{
		get { return _fruit; }
		set
		{
			_fruit = value;
			_fruit.transform.SetParent(transform, false);
		}
	}
}
