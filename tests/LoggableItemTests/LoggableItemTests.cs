using AutoLogger;
using AutoLogger.Contracts;
using System;
using Xunit;
using System.Collections.Generic;
using System.Reflection;

namespace LoggableItemTests {
    public class LoggableItemTests {

        [Fact]
        public void SingleItemFlagWorks() {
            LoggableItem item = LoggableItem.PublicMethods;
            Assert.True(item == LoggableItem.PublicMethods);
        }

        [Fact]
        public void AllFlagsSetWorks() {
            LoggableItem items = LoggableItem.PublicMethods |
                LoggableItem.InternalMethods |
                LoggableItem.PrivateMethods;

            Assert.True(
                (items & LoggableItem.PublicMethods) != 0 &&
                (items & LoggableItem.InternalMethods) != 0 &&
                (items & LoggableItem.PrivateMethods) != 0
            );
        }

        [Fact]
        public void MultipleButNotAllFlagsSetWorks() {
            LoggableItem items = LoggableItem.PublicMethods | LoggableItem.PrivateMethods;

            Assert.True(
                (items & LoggableItem.PublicMethods) != 0 &&
                (items & LoggableItem.PrivateMethods) != 0 &&
                (items & LoggableItem.InternalMethods) == 0
            );
        }

        //TODO(Logan) -> Refactor the code
        [Fact]
        public void LoggableAttributeHasItems() {
            IList<Assembly> assemblies = new List<Assembly>() {
                typeof(LoggableItemTests).GetTypeInfo().Assembly
            };

            LoggableItem items = LoggableItem.PublicMethods | LoggableItem.PrivateMethods;
            LoggableClass loggableClass = AutoLog.LocateLoggableClasses(assemblies)[0];
            Assert.True(
                (loggableClass.LoggableItems & items) != 0
            );
        }

    }

    [Loggable(LoggableItems = LoggableItem.PublicMethods | LoggableItem.PrivateMethods)]
    public class LoggableClassWithAttribute { }
}
