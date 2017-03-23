using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		internal static IList<object> LocateLoggableClasses(IList<Assembly> assembliesToSearch) {
			List<object> foundClasses = new List<object>();

			foreach (Assembly assembly in assembliesToSearch) {
				var loggableAttributeInfo = assembly.CustomAttributes
					.Where(x => x.AttributeType == typeof(LoggableAttribute))
					.Single();

				foundClasses.AddRange(
					assembly.DefinedTypes.Where(x => x.CustomAttributes.Contains(loggableAttributeInfo))
				);
			}

			return foundClasses;
		}
		
	}

}