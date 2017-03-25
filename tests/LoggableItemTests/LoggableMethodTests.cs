using AutoLogger.Contracts;
using System.Collections.Generic;
using System.Reflection;
using System;
using Xunit;

namespace LoggableItemTests {

	public class LoggableMethodTests {

		[Fact]
		public void PublicMethodsFound() {
			LoggableItem item = LoggableItem.PublicMethods;
			// IList<Type> loggableClasses = AutoLog.LocateLoggableClasses(null);
			// IList<MethodInfo> foundMethods = AutoLog.LocateLoggableMethods(loggableClasses, item);
		}

	}

	/*
    [Loggable(LoggableItems = LoggableItem.PublicMethods | LoggableItem.PrivateMethods)]
    public class LoggableClassWithAttribute {

        public void PublicMethod() { }
        private void PrivateMethod() { }

    }

	*/
}