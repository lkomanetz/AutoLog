using AutoLogger;
using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using static System.Console;

namespace ClassFinderTests {

    public class ClassFinderTests {

        [Fact]
        public void ClassesDenotedAsLoggableAreFound() {
            IList<string> classNames = new List<string>() {
                "PublicClass",
                "InternalClass",
                "NestedPrivateClass",
                "NestedProtectedClass"
            };
            int expectedCount = classNames.Count;

            IList<Assembly> assembliesToSearch = new List<Assembly>() {
                typeof(ClassFinderTests).GetTypeInfo().Assembly
            };

            IList<LoggableClass> loggableClasses = AutoLog.LocateLoggableClasses(assembliesToSearch);
            Assert.True(
                loggableClasses.Count == expectedCount,
                $"Expected Count: {expectedCount}\nActual: {loggableClasses.Count}"
            );

            foreach (LoggableClass foundClass in loggableClasses) {
                WriteLine($"Asserting type '{foundClass.Name}' is found.");
                Assert.True(classNames.Contains(foundClass.Name), $"Type '{foundClass.Name}' not found");
            }
        }

    }

    [Loggable]
    public class PublicClass {}

    [Loggable]
    internal class InternalClass {}

    public class NestedClasses {
        [Loggable]
        private class NestedPrivateClass {}

        [Loggable]
        protected class NestedProtectedClass {}
    }
}