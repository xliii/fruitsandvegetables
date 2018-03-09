using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
	[SerializeField]
	Button button;
	[SerializeField]
	FruitType type;	

	public FruitType Type
	{
		get { return type; }
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		var selected = The.SelectedFruit;
		if (selected == this)
		{
			Deselect();
		}
		else if (selected != null)
		{
			if (The.MatchRule.CanMatch(selected, this))
			{
				StartCoroutine(The.MatchRule.Match(selected, this));
				The.SelectedFruit = null;
			}
			else
			{
				selected.Deselect();
				Select();
			}
		}
		else
		{
			Select();
		}
	}

	public int GetIndex()
	{
		return transform.parent.GetSiblingIndex();
	}

	public Vector2Int GetPosition()
	{
		var index = GetIndex();
		return new Vector2Int(index % The.Width, index / The.Width);
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	public void Deselect()
	{
		if (The.SelectedFruit == this)
		{
			The.SelectedFruit.button.targetGraphic.color = Color.white;
			The.SelectedFruit = null;	
		}		
	}

	public void Select()
	{	
		The.SelectedFruit = this;
		The.SelectedFruit.button.targetGraphic.color = Color.red;
	}

	public override string ToString()
	{
		return string.Format("{0}({1})", Type, GetPosition());
	}
}
