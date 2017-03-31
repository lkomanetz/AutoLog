using AutoLogger;
using System;
using Xunit;

namespace ProxyGeneratorTests {

    public class ProxyGeneratorTests {

        private ProxyGenerator<TestClass> generator;

        public ProxyGeneratorTests() {
            generator = new ProxyGenerator<TestClass>();
        }

        [Fact]
        public void ProxyGeneratorCtorWorks() {
           Assert.True(
               generator.TypeToProxy.Name == typeof(TestClass).Name
           );
        }

    }

    internal class TestClass {

    }

}