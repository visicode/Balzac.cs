/*! ./cs/Regex.cs | MIT License | github.com/visicode/Balzac.cs */
using System.Text.RegularExpressions;

namespace Balzac.cs {
	public static class _Regex {

		// Adds predefined input Regex patterns to new _Regex.PATTERN object.
		public static class PATTERN {
			public static readonly Regex
				// Email address format following official specification.
				EMAIL = new Regex(@"^[A-Za-z0-9]+([._%+\-][A-Za-z0-9]+)*@[A-Za-z0-9]+([.\-][A-Za-z0-9]+)*\.[A-Za-z]{2,9}$", RegexOptions.Compiled),
				// One or more email addresses, separated by commas.
				EMAILS = new Regex(@"^[A-Za-z0-9]+([._%+\-][A-Za-z0-9]+)*@[A-Za-z0-9]+([.\-][A-Za-z0-9]+)*\.[A-Za-z]{2,9}(, ?[A-Za-z0-9]+([._%+\-][A-Za-z0-9]+)*@[A-Za-z0-9]+([.\-][A-Za-z0-9]+)*\.[A-Za-z]{2,9})*$", RegexOptions.Compiled),
				// Phone number in international or local format, with optional extension.
				PHONE = new Regex(@"^(\+[1-9][0-9]{0,2} ?)?(\([0-9]{1,4}\) ?)?[0-9]+([ .\-]?[0-9]+){6,}( ?#[0-9]{1,5})?$", RegexOptions.Compiled),
				// Eight characters minimum password with at least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character.
				PASSWORD = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", RegexOptions.Compiled),
				// Passport number in international format.
				PASSPORT = new Regex(@"^[Pp][A-Za-z<]{43}[A-Za-z0-9<]{9}[0-9][A-Za-z<]{3}[0-9]{7}[A-Za-z<][0-9]{7}[A-Za-z<]{14}[0-9<][0-9]$", RegexOptions.Compiled),
				// IBAN number from 16 to 39 characters, optionally grouped in blocks of 4.
				IBAN = new Regex(@"^[A-Za-z]{2}[0-9]{2}( ?[A-Za-z0-9]{4}){3,8}( ?[A-Za-z0-9]{1,3})?$", RegexOptions.Compiled),
				// Multi-countries postal code format.
				POSTCODE = new Regex(@"^([0-9]{2,5}([ \-]?[A-Za-z0-9]{1,6})?|[A-Za-z]{1,3}[0-9 ]( ?[A-Za-z0-9]){1,6})$", RegexOptions.Compiled);
		}
	}
}
