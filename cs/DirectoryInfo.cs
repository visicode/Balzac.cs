/*! ./cs/DirectoryInfo.cs | MIT License | github.com/visicode/Balzac.cs */
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Balzac.cs {
	public static class _DirectoryInfo {

		/// <summary>Checks if a directory is empty.</summary>
		/// <returns>true if the directory is empty or not existing, otherwise false.</returns>
		public static bool IsEmpty(this DirectoryInfo directoryInfo) {
			try {
				return !directoryInfo.Exists
					|| !directoryInfo.EnumerateFileSystemInfos().Any();
			}
			catch {
				return false;
			}
		}

		/// <summary>Tries to delete a directory, specifying whether to delete subdirectories and files.</summary>
		/// <param name="recursive">true to delete subdirectories and all files (false by default).</param>
		/// <returns>true if the directory has been deleted, otherwise false.</returns>
		public static bool TryDelete(this DirectoryInfo directoryInfo, bool recursive = false) {
			if (directoryInfo.Exists)
				try {
					if (!recursive && !directoryInfo.IsEmpty())
						return false; // faster than throwing an exception when not empty

					directoryInfo.Delete(recursive);
#if DEBUG
					Debug.WriteLine($"DirectoryInfo.TryDelete(): directory '{directoryInfo.Name}' deleted");
#endif
				}
				catch {
					return false;
				}

			return true;
		}
	}
}
