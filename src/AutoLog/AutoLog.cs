using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		internal static IList<object> LocateLoggableClasses(IList<Assembly> assembliesToSearch) {
			List<object> foundClasses = new List<object>();

			foreach (Assembly assembly in assembliesToSearch) {
				foreach (TypeInfo typeInfo in assembly.DefinedTypes) {
					var foundAttributes = typeInfo.CustomAttributes.Where(x => x.AttributeType == typeof(LoggableAttribute));
					foundClasses.AddRange(foundAttributes);
				}

				foreach (Type type in assembly.ExportedTypes) {
					TypeInfo typeInfo = type.GetTypeInfo();
					var foundAttributes = typeInfo.CustomAttributes.Where(x => x.AttributeType == typeof(LoggableAttribute));
					foundClasses.AddRange(foundAttributes);
				}
			}

			return foundClasses;
		}
		
	}

}