using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using AutoLogger.Contracts;

namespace AutoLogger {

	internal class LoggableClassFinder {
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
				IList<LoggableClass> loggableClasses = CreateLoggableClasses(assembly.DefinedTypes);

				if (loggableClasses.Count > 0)
					foundClasses.AddRange(CreateLoggableClasses(assembly.DefinedTypes));
			}

			return foundClasses;
		}

		private IList<LoggableClass> CreateLoggableClasses(IEnumerable<TypeInfo> typeInfoCollection) {
			IList<LoggableClass> loggableClasses = new List<LoggableClass>();

			foreach (TypeInfo typeInfo in typeInfoCollection) {
				var foundMethods = typeInfo.DeclaredMethods
					.Where(x => x.GetCustomAttributes().Where(a => a is BehaviorAttribute).Count() > 0)
					.ToList();

				if (foundMethods.Count < 1)
					continue;

				LoggableClass loggableClass = new LoggableClass() {
					ClassType = typeInfo.AsType()
				};

				loggableClass.Methods = foundMethods;
				loggableClasses.Add(loggableClass);
			}

			return loggableClasses;
		}

	}

}