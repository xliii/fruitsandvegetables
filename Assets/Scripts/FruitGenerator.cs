using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitGenerator : MonoBehaviour
{
	public Fruit[] fruits;

	void Awake()
	{
		The.Generator = this;
	}

	public int Init(int seed)
	{
		Random.InitState(seed);
		return seed;
	}

	public int Init()
	{
		var ticks = new TimeSpan(DateTime.Now.Ticks);
		return Init((int) ticks.TotalMinutes);
	}

	private Fruit GetRandomFruit(int fruitTypes)
	{
		return fruits[Random.Range(0, fruitTypes)];
	}

	public List<Fruit> GetRandomFruits(int size)
	{
		return GetRandomFruits(size, fruits.Length);
	}

	public List<Fruit> GetRandomFruits(int size, int fruitTypes)
	{
		var fruits = new List<Fruit>();
		int half = size / 2;
		for (var i = 0; i < half; i++)
		{
			fruits.Add(GetRandomFruit(fruitTypes));
		}		
		fruits.AddRange(fruits);
		Util.Shuffle(fruits);
		return fruits;
	}
}
