using System;
using System.Collections.Generic;

public class Util {

	public static List<T> Shuffle<T> (List<T>aList) {
		
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
}
