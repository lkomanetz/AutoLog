using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		internal static IList<LoggableClass> LocateLoggableClasses(IList<Assembly> assembliesToSearch) {
			List<LoggableClass> foundClasses = new List<LoggableClass>();
			return foundClasses;
		}

		//TODO(Logan) -> Implement this method to find the methods based on attribute property.
		internal static IList<MethodInfo> LocateLoggableMethods(IList<Type> loggableClasses, LoggableItem items) {
			IList<MethodInfo> loggableMethods = new List<MethodInfo>();
			bool getPublicMethods = (items & LoggableItem.PublicMethods) != 0;

			foreach (Type loggableClass in loggableClasses) {
				loggableMethods = loggableClass.GetRuntimeMethods()
					.Where(x => x.IsPublic && getPublicMethods)
					.ToList();
			}

			return loggableMethods;
		}
		
	}

}