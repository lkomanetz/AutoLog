using AutoLogger;
using System;

namespace LoggableClasses {

    public class PublicClass {
        [Log] public void PublicMethod() {}
    }

    internal class InternalClass {
        [Log] private void PrivateMethod() {}
    }

    public class NestedClass {

        private class NestedPrivateClass {
            [Log] internal void InternalMethod() {}
        }

        protected class NestedProtectedClass {
            [Log] protected void ProtectedMethod() {}
        }

    }

}
