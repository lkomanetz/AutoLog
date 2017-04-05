using AutoLogger;
using System;
using Xunit;

namespace DependencyContainerTests {

    public class DependencyContainerTests {

        [Fact]
        public void DependencyResolutionSucceeds() {
            DependencyContainer injector = new DependencyContainer();
            injector.Register<ITestInterface, TestClass>();
            object actualClass = injector.Resolve(typeof(ITestInterface));
            AssertResolution(actualClass, typeof(TestClass));

            actualClass = injector.Resolve<ITestInterface>();
            AssertResolution(actualClass, typeof(TestClass));
        }

        private void AssertResolution(object actualClass, Type expectedType) {
            Assert.NotNull(actualClass);
            Assert.True(
                actualClass.GetType().Name == typeof(TestClass).Name,
                $"Expected {typeof(TestClass).Name}\nWas {actualClass.GetType().Name}"
            );
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