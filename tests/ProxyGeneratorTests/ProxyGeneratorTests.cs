using AutoLogger;
using System;
using Xunit;

namespace ProxyGeneratorTests {

    public class ProxyGeneratorTests {

        private ProxyGenerator<ITestInterface> _generator;

        public ProxyGeneratorTests() {
            _generator = new ProxyGenerator<ITestInterface>();
        }

        [Fact]
        public void ProxyGeneratorCtorWorks() {
           Assert.True(
               _generator.TypeToProxy.Name == typeof(ITestInterface).Name
           );
        }

        [Fact]
        public void ProxyGeneratorCreatesInstanceDynamically() {
            var instance = _generator.Generate();
            Assert.NotNull(instance);
        }

    }

    internal interface ITestInterface {
        void DoSomething();
    }

    internal class TestClass : ITestInterface {
        public void DoSomething() {
            Console.WriteLine("I did something...");
        }
    }

}