/*! cs/Char.cs | MIT License | github.com/visicode/Balzac.cs */
using System.Globalization;

namespace Balzac.cs {
	public static class _char {

		/// <summary>Checks if a Unicode character is categorized as an uppercase letter.</summary>
		/// <returns>true if the Unicode character is categorized as an uppercase letter, otherwise false.</returns>
		public static bool IsUpper(this char c) {
			return char.IsUpper(c);
		}

		/// <summary>Checks if a Unicode character is categorized as a lowercase letter.</summary>
		/// <returns>true if the Unicode character is categorized as a lowercase letter, otherwise false.</returns>
		public static bool IsLower(this char c) {
			return char.IsLower(c);
		}

		/// <summary>Converts the value of a Unicode character to its uppercase equivalent.</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules (current culture by default).</param>
		/// <returns>The value of a Unicode character converted to its uppercase equivalent.</returns>
		public static char ToUpper(this char c, CultureInfo? culture = null) {
			return char.ToUpper(c, culture ?? CultureInfo.CurrentCulture);
		}

		/// <summary>Converts the value of a Unicode character to its lowercase equivalent.</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules (current culture by default).</param>
		/// <returns>The value of a Unicode character converted to its lowercase equivalent.</returns>
		public static char ToLower(this char c, CultureInfo? culture = null) {
			return char.ToLower(c, culture ?? CultureInfo.CurrentCulture);
		}

		/// <summary>Converts a Unicode character to its numeric value.</summary>
		/// <returns>The value of the Unicode character converted to its numeric value (-1 if not a digit).</returns>
		public static short ToNumericValue(this char c) {
			return (short)char.GetNumericValue(c);
		}
	}
}
