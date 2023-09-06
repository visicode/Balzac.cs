/*! ./cs/WebUtility.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Balzac.cs {
	public static class WebUtility {

		/// <summary>Encodes the specified binary string into base-64 digits.</summary>
		/// <param name="string">The binary string to encode (a string in which each character in the string is treated as a byte of binary data).</param>
		/// <param name="options">The encoding options (None by default).</param>
		/// <returns>The specified string encoded with base-64 digits.</returns>
		public static string BtoA(string @string, Base64FormattingOptions? options = null) {
			return Convert.ToBase64String(Encoding.GetEncoding(28591)
					.GetBytes(@string),
				options ?? Base64FormattingOptions.None);
		}

		/// <summary>Decodes the specified string, which encodes data as base-64 digits, back to its decoded form.</summary>
		/// <param name="string">The string containing base64-encoded data to decode.</param>
		/// <returns>The specified string decoded from base-64 digits.</returns>
		public static string AtoB(string @string) {
			return Encoding.GetEncoding(28591)
				.GetString(Convert.FromBase64String(@string));
		}

		/// <summary>Replaces all special characters of a string (other than letters, numbers and separators) with the specified replacement string.</summary>
		/// <param name="string">The string containing the special characters to be replaced.</param>
		/// <param name="replacement">The replacement string (empty string by default).</param>
		/// <returns>The new string with all special characters replaced.</returns>
		public static string StripSpecialChars(string @string, string? replacement = null) {
			return !string.IsNullOrEmpty(@string)
				? Regex.Replace(@string,
					@"[^\w\d\s]", replacement ?? string.Empty)
				: @string;
		}

		/// <summary>Converts a string with all new lines replaced with HTML line breaks.</summary>
		/// <param name="string">The string containing the new lines to be replaced.</param>
		/// <returns>The new string with new lines converted to HTML line breaks.</returns>
		public static string Nl2br(string @string) {
			return !string.IsNullOrEmpty(@string)
				? Regex.Replace(@string,
					@"\r?\n", "<br />")
				: @string;
		}

		/// <summary>Converts a string with all new lines replaced with HTML paragraphs.</summary>
		/// <param name="string">The string containing the new lines to be replaced.</param>
		/// <returns>The new string with new lines converted to HTML paragraphs.</returns>
		public static string Nl2p(string @string) {
			return !string.IsNullOrEmpty(@string)
				? "<p>" + Regex
					.Replace(@string,
						@"\r?\n", "</p><p>")
					+ "</p>"
				: @string;
		}

		/// <summary>Converts a string to its file name representation, with all invalid characters replaced with the specified replacement string.</summary>
		/// <param name="string">The string containing the invalid characters to be replaced.</param>
		/// <param name="replacement">The replacement string ("_" by default).</param>
		/// <returns>The string converted to a valid file name.</returns>
		public static string ToFileName(string @string, string? replacement = null) {
			return !string.IsNullOrEmpty(@string)
				? string.Join(replacement ?? "_",
					@string.Split(Path.GetInvalidFileNameChars()))
				: @string;
		}

		/// <summary>Converts an HTML string to plain text, with all HTML tags removed.</summary>
		/// <param name="string">The HTML string to be converted to plain text.</param>
		/// <returns>The new string with all HTML tags removed.</returns>
		public static string ToPlainText(string @string) {
			return !string.IsNullOrEmpty(@string)
				? HtmlDecode(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(@string,
					// treat new lines and subsequent indents as white spaces
					@"\r?\n[ \t]*", " "),
					// remove special HTML blocks
					@"<(audio|canvas|noscript|script|style|video)\b.*?<\/\1>", string.Empty, RegexOptions.IgnoreCase),
					// convert block-level HTML tags to new lines
					@"<\/?(address|article|aside|blockquote|dd|div|dl|dt|fieldset|figcaption|figure|footer|form|h[1-6]|header|li|main|nav|ol|p|pre|section|table|tfoot|ul)\b[^>]*>", Environment.NewLine, RegexOptions.IgnoreCase),
					// convert special HTML tags to new lines
					@"<(br|hr)\s*\/?>", Environment.NewLine, RegexOptions.IgnoreCase),
					// remove remaining HTML tags
					@"<[a-z!/][^>]*>", string.Empty, RegexOptions.IgnoreCase),
					// remove leading and trailing spaces from each line
					@"(^ +| +$)", string.Empty, RegexOptions.Multiline)
					// remove double spaces
					.Replace("  ", " ")
				)
				: @string;
		}

		public enum PASSWORD_STRENGTH : byte {
			[Description("Empty")]
			EMPTY = 0,  // Empty.
			[Description("Short")]
			SHORT = 1,  // Less than 8 characters.
			[Description("Weak")]
			WEAK = 2,   // One or two of the PASSWORD_STRENGTH.GOOD criteria.
			[Description("Medium")]
			MEDIUM = 3, // Three of the PASSWORD_STRENGTH.GOOD criteria.
			[Description("Good")]
			GOOD = 4,   // At least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character.
			[Description("Strong")]
			STRONG = 5  // All PASSWORD_STRENGTH.GOOD criteria and greater than or equal to 12 characters.
		}

		/// <summary>Returns the specified password strength.</summary>
		/// <param name="password">The string containing the password to rate.</param>
		/// <returns>The password strength from PASSWORD_STRENGTH.EMPTY to PASSWORD_STRENGTH.STRONG.</returns>
		public static PASSWORD_STRENGTH GetPasswordStrength(string password) {
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

		// mappings to call initial WebUtility class methods //TODO: update if changed
		public static string HtmlDecode(string value) => System.Net.WebUtility.HtmlDecode(value);
		public static void HtmlDecode(string value, TextWriter output) => System.Net.WebUtility.HtmlDecode(value, output);
		public static string HtmlEncode(string value) => System.Net.WebUtility.HtmlEncode(value);
		public static void HtmlEncode(string value, TextWriter output) => System.Net.WebUtility.HtmlEncode(value, output);
		public static string UrlDecode(string encodedValue) => System.Net.WebUtility.UrlDecode(encodedValue);
		public static byte[] UrlDecodeToBytes(byte[] encodedValue, int offset, int count) => System.Net.WebUtility.UrlDecodeToBytes(encodedValue, offset, count);
		public static string UrlEncode(string value) => System.Net.WebUtility.UrlEncode(value);
		public static byte[] UrlEncodeToBytes(byte[] value, int offset, int count) => System.Net.WebUtility.UrlEncodeToBytes(value, offset, count);
	}
}
