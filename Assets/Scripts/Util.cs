using System;
using System.Collections.Generic;

public static class Util {

	public static List<T> Shuffle<T> (this List<T>aList) {
		
		var random = new Random ();

		var size = aList.Count;
		for (var i = 0; i < size; i++)
		{
			// NextDouble returns a random number between 0 and 1.
			// ... It is equivalent to Math.random() in Java.
			var r = i + (int)(random.NextDouble() * (size - i));
			var item = aList[r];
			aList[r] = aList[i];
			aList[i] = item;
		}
 
		return aList;
	}

	public static string AsString<T>(this List<T> list)
	{
		return string.Join(", ", Array.ConvertAll(list.ToArray(), pos => pos.ToString()));
	}
}
