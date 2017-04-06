using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public static class AutoLog {

		private static bool _isFrozen;

		public static void With(Assembly assembly) {
			var classFinder = new LoggableClassFinder(assembly);
			LoggableClasses = classFinder.FindLoggableClasses();
		}

		private static IList<LoggableClass> _loggableClasses;
		private static IList<LoggableClass> LoggableClasses {
			get { return _loggableClasses; }
			set {
				if (!_isFrozen) {
					_loggableClasses = value;
				}
			}
		}

		private static DependencyMap _dependencyMap;
		private static DependencyMap DependencyMap {
			get { return _dependencyMap; }
			set {
				if (!_isFrozen) {
					_dependencyMap = value;
				}
			}
		}

		public static void With(IList<Assembly> assemblies) {
			var classFinder = new LoggableClassFinder(assemblies);
			LoggableClasses = classFinder.FindLoggableClasses();
		}

		public static void With(DependencyMap map) {
			_dependencyMap = map;
		}

		public static void Freeze() {
			_isFrozen = true;
		}

	}

}