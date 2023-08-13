/*! cs/HtmlHelper.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Balzac.cs {
	public static class HtmlHelper {

		/// <summary>Encodes the specified binary string into base-64 digits.</summary>
		/// <param name="s">The binary string to encode (a string in which each character in the string is treated as a byte of binary data).</param>
		/// <param name="options">The encoding options (None by default).</param>
		/// <returns>The specified string encoded with base-64 digits.</returns>
		public static string BtoA(string s, Base64FormattingOptions? options = null) {
			return Convert.ToBase64String(Encoding.GetEncoding(28591)
				.GetBytes(s), options ?? Base64FormattingOptions.None);
		}

		/// <summary>Decodes the specified string, which encodes data as base-64 digits, back to its decoded form.</summary>
		/// <param name="s">The string containing base64-encoded data to decode.</param>
		/// <returns>The specified string decoded from base-64 digits.</returns>
		public static string AtoB(string s) {
			return Encoding.GetEncoding(28591)
				.GetString(Convert.FromBase64String(s));
		}

		public enum PASSWORD_STRENGTH : byte {
			EMPTY = 0,	// Empty.
			SHORT = 1,	// Less than 8 characters.
			WEAK = 2,   // One or two of the PASSWORD_STRENGTH.GOOD criteria.
			MEDIUM = 3, // Three of the PASSWORD_STRENGTH.GOOD criteria.
			GOOD = 4,	// At least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character.
			STRONG = 5  // All PASSWORD_STRENGTH.GOOD criteria and greater than or equal to 12 characters.
		}

		/// <summary>Returns the specified password strength.</summary>
		/// <param name="password">The string containing the password to rate.</param>
		/// <returns>The password strength from PASSWORD_STRENGTH.EMPTY to PASSWORD_STRENGTH.STRONG.</returns>
		public static PASSWORD_STRENGTH GetPasswordStrength(string? password) {
			PASSWORD_STRENGTH score = !string.IsNullOrEmpty(password)
				? password.Length >= 8
					? (PASSWORD_STRENGTH)Math.Max((byte)new bool[] {
							Regex.IsMatch(password, @"[a-z]"), // lowercase letter
							Regex.IsMatch(password, @"[A-Z]"), // uppercase letter
							Regex.IsMatch(password, @"\d"), // decimal digit
							Regex.IsMatch(password, @"\W") // non-word character
						}.Count(x => x),
						(byte)PASSWORD_STRENGTH.WEAK)
					: PASSWORD_STRENGTH.SHORT
				: PASSWORD_STRENGTH.EMPTY;
			return score < PASSWORD_STRENGTH.GOOD || password?.Length < 12
				? score
				: PASSWORD_STRENGTH.STRONG;
		}
	}
}
