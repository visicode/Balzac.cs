/*! ./cs/TimeZoneInfo.cs | MIT License | github.com/visicode/Balzac.cs */
using System;

namespace Balzac.cs {
	public static class _TimeZoneInfo {

		/// <summary>Returns a time zone display name in short format.</summary>
		/// <returns>The time zone display name in short format (without the UTC time offset).</returns>
		public static string ToShortName(this TimeZoneInfo timeZoneInfo) {
			return timeZoneInfo.DisplayName[(timeZoneInfo.DisplayName.IndexOf(") ", StringComparison.Ordinal) + 2)..];
		}
	}
}
