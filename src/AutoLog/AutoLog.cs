using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		private static LoggableClassFinder _classFinder;
		private static IList<LoggableClass> _loggableClasses;

		public static void With(Assembly assembly) {
			_classFinder = new LoggableClassFinder(assembly);
			_loggableClasses = _classFinder.FindLoggableClasses();
		}

		public static void With(IList<Assembly> assemblies) {
			_classFinder = new LoggableClassFinder(assemblies);
			_loggableClasses = _classFinder.FindLoggableClasses();
		}

	}

}