using AutoLogger;
using System;
using Xunit;
using System.Collections.Generic;
using System.Reflection;

namespace ClassFinderTests {

    public class ClassFinderTests {

        [Fact]
        public void ClassesDenotedAsLoggableAreFound() {
            IList<Assembly> assembliesToSearch = new List<Assembly>() {
                this.GetType().GetTypeInfo().Assembly
            };
            var loggableClasses = AutoLog.LocateLoggableClasses(assembliesToSearch);
            Assert.True(loggableClasses.Count == 1);
        }

    }

    [Loggable]
    public class PublicClass {

    }

}