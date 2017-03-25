using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		internal static IList<LoggableClass> LocateLoggableClasses(IList<Assembly> assembliesToSearch) {
			List<LoggableClass> foundClasses = new List<LoggableClass>();

			foreach (Assembly assembly in assembliesToSearch) {
				var typeInfoList = assembly.DefinedTypes
					.Where(typeInfo => {
						var foundItems = typeInfo.CustomAttributes
							.Where(a => a.AttributeType == typeof(LoggableAttribute));

						return foundItems.Count() > 0;
					})
					.Select(y => y);
				foundClasses.AddRange(CreateLoggableClasses(typeInfoList));
			}

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

		private static IList<LoggableClass> CreateLoggableClasses(IEnumerable<TypeInfo> typeInfos) {
			IList<LoggableClass> loggableClasses = new List<LoggableClass>();
			foreach (TypeInfo typeInfo in typeInfos) {
				LoggableClass loggableClass = new LoggableClass() {
					ClassType = typeInfo.AsType()
				};
				var attribute = (LoggableAttribute)typeInfo.GetCustomAttribute(typeof(LoggableAttribute));
				loggableClass.LoggableItems = attribute.LoggableItems;

				loggableClasses.Add(loggableClass);
			}

			return loggableClasses;
		}
		
	}

}