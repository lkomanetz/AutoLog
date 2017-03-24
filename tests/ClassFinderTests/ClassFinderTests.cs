using AutoLogger;
using System;
using Xunit;
using System.Collections.Generic;
using System.Reflection;
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

            var loggableClasses = AutoLog.LocateLoggableClasses(assembliesToSearch);
            Assert.True(
                loggableClasses.Count == expectedCount,
                $"Expected Count: {expectedCount}\nActual: {loggableClasses.Count}"
            );

            foreach (Type foundType in loggableClasses) {
                WriteLine($"Asserting type '{foundType.Name}' is found.");
                Assert.True(classNames.Contains(foundType.Name), $"Type '{foundType.Name}' not found");
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