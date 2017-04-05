using AutoLogger;
using System;
using Xunit;

namespace ProxyGeneratorTests {

    public class ProxyGeneratorTests {

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