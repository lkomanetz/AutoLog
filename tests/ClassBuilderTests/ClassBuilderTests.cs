using LoggableClasses;
using AutoLogger.Contracts;
using AutoLogger;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Xunit;

namespace ClassBuilderTests {

    public class ClassBuilderTests {
        private IList<LoggableClass> _loggableClasses;

        public ClassBuilderTests() {
            Assembly assembly = typeof(PublicClass).GetTypeInfo().Assembly;
            var classFinder = new LoggableClassFinder(assembly);
            _loggableClasses = classFinder.FindLoggableClasses();
        }

        [Fact]
        public void ClassBuilderGeneratesCorrectOpCodes() {
            ClassBuilder cb = new ClassBuilder();
            MethodInfo method = _loggableClasses[0].Methods[0];
            IList<OpCode> opCodes = cb.GenerateOpCodes(method);
            Assert.NotNull(opCodes);
            //TODO(Logan) -> Get back into the red with red/green/refactor
        }

        [Fact]
        public void OperationCodesGenerateCorrectly() {
        }

    }

}
