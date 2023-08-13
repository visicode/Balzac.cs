using System;
using System.Collections.Generic;

namespace Balzac.cs {
	public class Program {

		/// <summary>Balzac.cs C# library tests</summary>
		public static void Main() {
			Console.WriteLine(Balzac.GetInfo());

			Console.WriteLine("{HELLO} {UNKNOWN}<b>{WORLD}!</b><br />not visible&hellip;"
				.ToPlainText()
				.FormatNamed(new Dictionary<string, object>() {
					[key: "HELLO"] = "hello",
					["WORLD"] = "world",
					["Unknown"] = "not used"
				})
				.Truncate(22)
				.ToSentenceCase()
				.FirstLines(1)
			);

			Console.WriteLine("Password strength: {0}",
				HtmlHelper.GetPasswordStrength("Abcde12345*!"));
		}
	}
}
