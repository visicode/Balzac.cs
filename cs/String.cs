/*! cs/String.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Balzac.cs {
	public static class _string {

		/// <summary>Checks if a string is all in uppercase letters.</summary>
		/// <returns>true if the string is all in uppercase letters, otherwise false.</returns>
		public static bool IsUpper(this string? s) {
			return s != null && !s.Any(char.IsLower);
		}

		/// <summary>Checks if a string is all in lowercase letters.</summary>
		/// <returns>true if the string is all in lowercase letters, otherwise false.</returns>
		public static bool IsLower(this string? s) {
			return s != null && !s.Any(char.IsUpper);
		}

		/// <summary>Converts a string to title case (every major word capitalized).</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules (current culture by default).</param>
		/// <returns>The new string converted to title case.</returns>
		public static string? ToTitleCase(this string? s, CultureInfo? culture = null) {
			return !string.IsNullOrEmpty(s)
				? Regex.Replace(s.Length > 3 && s.IsUpper() ? s.ToLower(culture ?? CultureInfo.CurrentCulture) : s,
					@"\w\S*", match => char.ToUpper(match.Value[0], culture ?? CultureInfo.CurrentCulture) + match.Value[1..])
					.Replace("  ", " ")
					.TrimLines()
				: null;
		}

		/// <summary>Converts a string to sentence case (first word of every sentence capitalized).</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules (current culture by default).</param>
		/// <returns>The new string converted to sentence case.</returns>
		public static string? ToSentenceCase(this string? s, CultureInfo? culture = null) {
			return !string.IsNullOrEmpty(value: s)
				? Regex.Replace(s.Length > 3 && s.IsUpper() ? s.ToLower(culture ?? CultureInfo.CurrentCulture) : s,
					@"(^\s*\w{1}|[.!?]\s+\w{1})", match => match.Value.ToUpper(culture ?? CultureInfo.CurrentCulture), RegexOptions.Multiline)
					.Replace("  ", " ")
					.TrimLines()
				: null;
		}

		/// <summary>Replaces the format named items in a string with the string representations of corresponding objects in the specified dictionary.</summary>
		/// <param name="args">The dictionary that contains the keys and their object values to format.</param>
		/// <param name="culture">An object that supplies culture-specific formatting rules (current culture by default).</param>
		/// <returns>The new string in which the format named items have been replaced by the string representation of the corresponding object in args (or an empty string if not found).</returns>
		public static string? FormatNamed(this string? format, Dictionary<string, object> args, CultureInfo? culture = null) {
			if (!string.IsNullOrEmpty(value: format) && args != null) {
				string[] keys = args.Keys.ToArray();
				return string.Format(culture ?? CultureInfo.CurrentCulture,
					Regex.Replace(format,
						@"{([^}:]+)([^}]*)}", match => {
							int index = Array.IndexOf(keys,
								match.Groups[1].Value);
							return index > -1
								? '{' + index.ToString(CultureInfo.InvariantCulture) + match.Groups[2].Value + '}'
								: string.Empty;
						}),
					args.Values.ToArray()
				);
			}
			else
				return null;
		}

		/// <summary>Removes leading and trailing white-space characters from each line of a string.</summary>
		/// <returns>The new string with leading and trailing white-space characters removed from each line.</returns>
		public static string? TrimLines(this string? s) {
			return !string.IsNullOrEmpty(s)
				? Regex.Replace(s,
					@"(^ +| +$)", string.Empty, RegexOptions.Multiline)
					.Trim()
				: null;
		}

		/// <summary>Truncates a string to the nearest word, with a trailing ellipsis if needed.</summary>
		/// <param name="max">The maximum number of characters to return.</param>
		/// <returns>The new string truncated to the nearest word.</returns>
		public static string? Truncate(this string? s, int max) {
			if (!string.IsNullOrEmpty(s) && max > 0 && s.Length > max) {
				string text = s[..max];
				Match match = Regex.Match(text, @"\W+(?:.(?!\W))+$");
				return text[..(match.Success ? match.Index : max - 1)] + '…';
			}
			else
				return s;
		}

		/// <summary>Returns only the first lines of a string.</summary>
		/// <param name="lines">The number of lines to return.</param>
		/// <returns>The new string reduced to the specified number of lines.</returns>
		public static string? FirstLines(this string? s, int lines) {
			if (!string.IsNullOrEmpty(s))
				return string.Join(Environment.NewLine,
					new Regex(@"\r?\n").Split(s, lines + 1).Take(lines));
			else
				return s;
		}

		/// <summary>Replaces all special characters of a string (other than letters, numbers and separators) with the specified replacement string.</summary>
		/// <param name="replacement">The replacement string (empty string by default).</param>
		/// <returns>The new string with all special characters replaced.</returns>
		public static string? StripSpecialChars(this string? s, string? replacement = null) {
			return !string.IsNullOrEmpty(s)
				? Regex.Replace(s, @"[^\w\d\s]", replacement ?? string.Empty)
				: null;
		}

		/// <summary>Converts a string to its file name representation, with all invalid characters replaced with the specified replacement string.</summary>
		/// <param name="replacement">The replacement string ("_" by default).</param>
		/// <returns>The string converted to a valid file name.</returns>
		public static string? ToFileName(this string? s, string? replacement = null) {
			return !string.IsNullOrEmpty(s)
				? string.Join(replacement ?? "_", s.Split(Path.GetInvalidFileNameChars()))
				: null;
		}

		/// <summary>Converts an HTML string to plain text, with all HTML tags removed.</summary>
		/// <returns>The new string with all HTML tags removed.</returns>
		public static string? ToPlainText(this string? s) {
			return !string.IsNullOrEmpty(s)
				? WebUtility.HtmlDecode(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(s,
					// treat new lines and subsequent indents as white spaces
					@"\r?\n[ \t]*", " "),
					// remove special HTML blocks
					@"<(audio|canvas|noscript|script|style|video)\b.*?<\/\1>", string.Empty, RegexOptions.IgnoreCase),
					// convert block-level HTML tags to new lines
					@"<\/?(address|article|aside|blockquote|dd|div|dl|dt|fieldset|figcaption|figure|footer|form|h[1-6]|header|li|main|nav|ol|p|pre|section|table|tfoot|ul)\b[^>]*>", Environment.NewLine, RegexOptions.IgnoreCase),
					// convert special HTML tags to new lines
					@"<(br|hr)\s*\/?>", Environment.NewLine, RegexOptions.IgnoreCase),
					// remove remaining HTML tags
					@"<[^>]+>", string.Empty)
					.Replace("  ", " ")
					.TrimLines()
				)
				: null;
		}

		/// <summary>Converts a string with all new lines replaced with HTML line breaks.</summary>
		/// <returns>The new string with new lines converted to HTML line breaks.</returns>
		public static string? Nl2br(this string? s) {
			return !string.IsNullOrEmpty(s)
				? Regex.Replace(s, @"\r?\n", "<br />")
				: null;
		}

		/// <summary>Converts a string with all new lines replaced with HTML paragraphs.</summary>
		/// <returns>The new string with new lines converted to HTML paragraphs.</returns>
		public static string? Nl2p(this string? s) {
			return !string.IsNullOrEmpty(s)
				? "<p>" + Regex.Replace(s, @"\r?\n", "</p><p>") + "</p>"
				: null;
		}
	}
}
