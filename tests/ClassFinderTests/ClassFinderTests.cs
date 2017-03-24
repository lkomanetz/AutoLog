using AutoLogger;
using System;
using Xunit;
using System.Collections.Generic;
using System.Reflection;

namespace ClassFinderTests {

    public class ClassFinderTests {

        [Fact]
        public void ClassesDenotedAsLoggableAreFound() {
            int expectedCount = 3;
            IList<Assembly> assembliesToSearch = new List<Assembly>() {
                typeof(ClassFinderTests).GetTypeInfo().Assembly
            };
            var loggableClasses = AutoLog.LocateLoggableClasses(assembliesToSearch);
            Assert.True(
                loggableClasses.Count == expectedCount,
                $"Expected Count: {expectedCount}\nActual: {loggableClasses.Count}"
            );
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