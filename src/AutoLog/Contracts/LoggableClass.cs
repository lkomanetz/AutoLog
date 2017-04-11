using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoLogger {
	namespace Contracts {

		public class LoggableClass {

			public LoggableClass() {
				this.Methods = new List<MethodInfo>();
			}

			public Type ClassType { get; set; } 
			public IList<MethodInfo> Methods { get; set; }
			public string Name => ClassType.Name;

		}

	}

}