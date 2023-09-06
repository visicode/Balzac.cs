/*! ./cs/Array.cs | MIT License | github.com/visicode/Balzac.cs */
using System;

namespace Balzac.cs {
	public static class _Array {

		/// <summary>Performs the specified action on each element of an array.</summary>
		/// <param name="action">The action to perform on each element of the array.</param>
		/// <returns>The initial array.</returns>
		public static T[] ForEach<T>(this T[] array, Action<T> action) {
			Array.ForEach(array,
				action: action);
			return array;
		}

		/// <summary>Performs the specified action on each element of an array.</summary>
		/// <param name="action">The action to perform on each element of the array.</param>
		/// <returns>The initial array.</returns>
		public static T[] ForEach<T>(this T[] array, Action<T, int> action) {
			for (int i = 0; i < array.Length; i++)
				action(array[i], i);
			return array;
		}
	}
}
