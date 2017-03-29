using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using AutoLogger.Contracts;

namespace AutoLogger {

	public class LoggableClassFinder {
		private readonly IList<Assembly> _assembliesToSearch;

		public LoggableClassFinder(IList<Assembly> assembliesToSearch) {
			_assembliesToSearch = assembliesToSearch;
		}

		public LoggableClassFinder(Assembly assemblyToSearch) {
			_assembliesToSearch = new List<Assembly>() { assemblyToSearch };
		}

		public IList<LoggableClass> FindLoggableClasses() {
			List<LoggableClass> foundClasses = new List<LoggableClass>();

			foreach (Assembly assembly in _assembliesToSearch) {
				var typeInfoList = assembly.DefinedTypes
					.Where(t => {
						return t.CustomAttributes.Where(a => a.AttributeType == typeof(LoggableAttribute)).Count() > 0;
					})
					.Select(typeInfo => typeInfo);

				foundClasses.AddRange(CreateLoggableClasses(typeInfoList));
			}
			return foundClasses;
		}

		private IList<LoggableClass> CreateLoggableClasses(IEnumerable<TypeInfo> typeInfoCollection) {
			IList<LoggableClass> loggableClasses = new List<LoggableClass>();
			foreach (TypeInfo typeInfo in typeInfoCollection) {
				LoggableClass loggableClass = new LoggableClass() {
					ClassType = typeInfo.AsType()
				};

				var attribute = (LoggableAttribute)typeInfo.GetCustomAttribute(typeof(LoggableAttribute));
				loggableClass.Methods = FindLoggableMethods(typeInfo);
				loggableClasses.Add(loggableClass);
			}

			return loggableClasses;
		}

		private IList<MethodInfo> FindLoggableMethods(TypeInfo typeInfo) {
			return typeInfo.AsType().GetRuntimeMethods()
				.Where(t => {
					return t.CustomAttributes.Where(c => c.AttributeType == typeof(LogAttribute)).Count() > 0;
				})
				.ToList();
		}

	}

}