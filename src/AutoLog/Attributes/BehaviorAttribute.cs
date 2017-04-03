using System;

namespace AutoLogger {

	[AttributeUsageAttribute(AttributeTargets.Method)]
	public abstract class BehaviorAttribute : System.Attribute {

		public abstract void Invoke(object[] args);

	}

}
