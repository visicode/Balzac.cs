using System;
using System.Collections.Generic;

namespace Balzac.cs {
	public class Program {

		/**** Balzac.cs C# library – Console tests */
		public static void Main() {
			Console.WriteLine(Balzac.GetInfo() + Environment.NewLine);

			Console.WriteLine(WebUtility
				.ToPlainText("<br />{HELLO}&nbsp;{UNKNOWN}<b>{WORLD}!</b><br />not visible"
					.FormatNamed(new Dictionary<string, object>() {
						[key: "HELLO"] = "hello",
						["WORLD"] = "world",
						["WORLd"] = "mars",
						["Unknown"] = "not used"
					}))
				.Truncate(22)
				.ToSentenceCase()
				.FirstLines(1) + Environment.NewLine
			);

			Console.WriteLine("Password strength: {0}" + Environment.NewLine,
				WebUtility.GetPasswordStrength("Abcde12345*!").GetDescription());
		}
	}
}
