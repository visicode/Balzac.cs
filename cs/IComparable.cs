/*! cs/IComparable.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.Collections.Generic;

namespace Balzac.cs {
	public static class _IComparable {

		/// <summary>Checks if an item is between two values, bounds included.</summary>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns>true if the item is between min and max included, otherwise false.</returns>
		public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T> {
			return Comparer<T>.Default.Compare(value, min) >= 0
				&& Comparer<T>.Default.Compare(value, max) <= 0;
		}

		/// <summary>Checks if an item is between two values, bounds excluded.</summary>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns>true if the item is between min and max excluded, otherwise false.</returns>
		public static bool IsBetweenExclusive<T>(this T value, T min, T max) where T : IComparable<T> {
			return Comparer<T>.Default.Compare(value, min) > 0
				&& Comparer<T>.Default.Compare(value, max) < 0;
		}
	}
}
