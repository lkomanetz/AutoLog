using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		internal static IList<Type> LocateLoggableClasses(IList<Assembly> assembliesToSearch) {
			List<Type> foundClasses = new List<Type>();

			foreach (Assembly assembly in assembliesToSearch) {
				var typeInfoList = assembly.DefinedTypes
					.Where(typeInfo => {
						var foundItems = typeInfo.CustomAttributes
							.Where(a => a.AttributeType == typeof(LoggableAttribute));

						return foundItems.Count() > 0;
					})
					.Select(y => y);

				foundClasses.AddRange(typeInfoList.Select(x => x.AsType()));
			}

			return foundClasses;
		}

		//TODO(Logan) -> Implement this method to find the methods based on attribute property.
		internal static IList<MethodInfo> LocateLoggableMethods(IList<Type> loggableClasses) {
			return new List<MethodInfo>();
		}
		
	}

}