using AutoLogger;
using System;
using Xunit;

namespace DependencyMapTests {

    public class DependencyMapTests {

        [Fact]
        public void DependencyResolutionSucceeds() {
            DependencyMap injector = new DependencyMap();
            injector.Register<ITestInterface, TestClass>();
            object actualClass = injector.Resolve(typeof(ITestInterface));
            AssertResolution(actualClass, typeof(TestClass));

            actualClass = injector.Resolve<ITestInterface>();
            AssertResolution(actualClass, typeof(TestClass));
        }

        [Fact]
        public void InnerDependenciesSucceeds() {
            DependencyMap injector = new DependencyMap();
            injector.Register<IInterface, AnotherClass>();
            var actualClass = (AnotherClass)injector.Resolve(typeof(IInterface));
            AssertResolution(actualClass, typeof(AnotherClass));
			Assert.True(actualClass.Blah == null);

			injector.Register<ITestInterface, TestClass>();
            actualClass = (AnotherClass)injector.Resolve(typeof(IInterface));
            Assert.True(
                actualClass.Blah.GetType() == typeof(TestClass),
                $"Expected {typeof(TestClass).Name}\nWas {actualClass.Blah.GetType().Name}"
            );
        }

        [Fact]
        public void MultipleRegistersStillProducesCorrectResult() {
            DependencyMap injector = new DependencyMap();
            injector.Register<ITestInterface, TestClass>();
            injector.Register<ITestInterface, TestClass>();
            object actualClass = injector.Resolve<ITestInterface>();
            AssertResolution(actualClass, typeof(TestClass));
        }

        private void AssertResolution(object actualClass, Type expectedType) {
            Assert.NotNull(actualClass);
            Assert.True(
                actualClass.GetType().Name == expectedType.Name,
                $"Expected {expectedType.Name}\nWas {actualClass.GetType().Name}"
            );
        }

    }

    internal interface ITestInterface {
        void DoSomething();
    }

    internal interface IInterface {}

    internal class TestClass : ITestInterface {
        public void DoSomething() {
            Console.WriteLine("I did something...");
        }
    }

    internal class AnotherClass : IInterface {
        public AnotherClass(ITestInterface blah) {
            this.Blah = blah;
        }

        internal ITestInterface Blah { get; private set; }
    }

}