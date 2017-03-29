using System;

namespace AutoLogger {

	[AttributeUsageAttribute(AttributeTargets.Method)]
	public class LogAttribute : System.Attribute
	{ }

}