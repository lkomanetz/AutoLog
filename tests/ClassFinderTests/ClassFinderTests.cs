using AutoLogger;
using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace ClassFinderTests {
    using static System.Console;

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
            int expectedMethodCount = 1;

            Assembly thisAssembly = typeof(ClassFinderTests).GetTypeInfo().Assembly;
            LoggableClassFinder finder = new LoggableClassFinder(thisAssembly);

            IList<LoggableClass> loggableClasses = finder.FindLoggableClasses();
            Assert.True(
                loggableClasses.Count == expectedCount,
                $"Expected Count: {expectedCount}\nActual: {loggableClasses.Count}"
            );

            foreach (LoggableClass foundClass in loggableClasses) {
                WriteLine($"Asserting type '{foundClass.Name}' is found.");
                Assert.True(classNames.Contains(foundClass.Name), $"Type '{foundClass.Name}' not found");
                Assert.True(
                    foundClass.Methods.Count == expectedMethodCount,
                    $"Found '{foundClass.Methods.Count}' methods.\t Expected {expectedMethodCount}"
                );
            }
        }

    }

    public class PublicClass {
        [Log] public void PublicMethod() {}
    }

    internal class InternalClass {
        [Log] private void PrivateMethod() {}
    }

    public class NestedClasses {
        private class NestedPrivateClass {
            [Log] internal void InternalMethod() {}
        }

        protected class NestedProtectedClass {
            [Log] protected void ProtectedMethod() {}
        }
    }
}