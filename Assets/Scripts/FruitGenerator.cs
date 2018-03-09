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

	public Fruit GetRandomFruit()
	{
		return fruits[Random.Range(0, fruits.Length)];
	}

	public List<Fruit> GetRandomFruits(int size)
	{
		var fruits = new List<Fruit>();
		int half = size / 2;
		for (var i = 0; i < half; i++)
		{
			fruits.Add(GetRandomFruit());
		}		
		fruits.AddRange(fruits);
		Util.Shuffle(fruits);
		return fruits;
	}
}
