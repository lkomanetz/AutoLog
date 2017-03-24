using AutoLogger;
using System.Collections.Generic;
using System.Reflection;
using System;
using Xunit;

namespace LoggableItemTests {

	public class LoggableMethodTests {

		[Fact]
		public void PublicMethodsFound() {
			IList<Type> loggableClasses = AutoLog.LocateLoggableClasses(null);
			IList<MethodInfo> foundMethods = AutoLog.LocateLoggableMethods(loggableClasses);
		}

	}

}