/*! ./cs/Enum.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.ComponentModel;

namespace Balzac.cs {
	public static class _Enum {

		/// <summary>Returns the description associated to an enum value.</summary>
		/// <returns>The enum value description if existing, the enum name otherwise.</returns>
		public static string GetDescription(this Enum @enum) {
			DescriptionAttribute[]? attributes = (DescriptionAttribute[]?)@enum
				.GetType()
				.GetField(@enum.ToString())
				?.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attributes != null && attributes.Length > 0
				? attributes[0].Description
				: @enum.ToString().Replace('_', ' ');
		}
	}
}
