/*! ./cs/Object.cs | MIT License | github.com/visicode/Balzac.cs */
using System.Reflection;

namespace Balzac.cs {
	public static class _Object {

		/// <summary>Returns the specific public property value of an object.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <returns>The property value of the object if existing, otherwise null.</returns>
		public static object? GetPropertyValue(this object obj, string name) {
			return obj.GetType().GetProperty(name)
				?.GetValue(obj, null);
		}

		/// <summary>Returns the specific property value of an object, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitwise combination of the enumeration values that specify how the search is conducted.</param>
		/// <returns>The property value of the object if existing, otherwise null.</returns>
		public static object? GetPropertyValue(this object obj, string name, BindingFlags bindingAttr) {
			return obj.GetType().GetProperty(name, bindingAttr)
				?.GetValue(obj, null);
		}
	}
}
