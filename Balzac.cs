/*! Balzac.cs v0.1.1 | MIT License | github.com/visicode/Balzac.cs */
using System.IO;
using System.Runtime.CompilerServices;

namespace Balzac.cs {
	public static class Balzac {

		private static string BalzacFilePath([CallerFilePath] string? _do_not_specify_ = null) {
			return _do_not_specify_ ?? string.Empty;
		}

		public static string? GetInfo() {
			using StreamReader stream = File.OpenText(BalzacFilePath());
			string? info = stream.ReadLine();
			stream.Close();
			return info;
		}
	}
}
