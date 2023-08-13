/*! cs/FileInfo.cs | MIT License | github.com/visicode/Balzac.cs */
using System.Diagnostics;
using System.IO;

namespace Balzac.cs {
	public static class _FileInfo {

		// Adds size constants to new _FileInfo.SIZE object to help converting file sizes from bytes.
		public static class SIZE {
			public static readonly ulong
				KILOBYTE = 1024L,
				MEGABYTE = 1024L * 1024L,
				GIGABYTE = 1024L * 1024L * 1024L,
				TERABYTE = 1024L * 1024L * 1024L * 1024L;
		}

		/// <summary>Tries to delete a file.</summary>
		/// <returns>true if the file has been deleted, otherwise false.</returns>
		public static bool TryDelete(this FileInfo fileInfo) {
			if (fileInfo != null && fileInfo.Exists)
				try {
					fileInfo.Delete();
#if DEBUG
					Debug.WriteLine($"FileInfo.TryDelete(): file '{fileInfo.Name}' deleted");
#endif
				}
				catch {
					return false;
				}

			return true;
		}
	}
}
