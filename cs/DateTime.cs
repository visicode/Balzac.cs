/*! ./cs/DateTime.cs | MIT License | github.com/visicode/Balzac.cs */
using System;
using System.Globalization;

namespace Balzac.cs {
	public static class _DateTime {

		/// <summary>Converts the value of a DateTime object to its SQL format representation.</summary>
		/// <returns>The DateTime converted to SQL format (yyyy-MM-dd HH:mm:ss.fff).</returns>
		public static string ToSqlString(this DateTime datetime) {
			return datetime.ToString("yyyy-MM-dd HH:mm:ss.fff",
				CultureInfo.InvariantCulture);
		}
	}
}
