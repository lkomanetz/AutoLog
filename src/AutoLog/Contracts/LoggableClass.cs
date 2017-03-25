using System;

namespace AutoLogger {
	namespace Contracts {

		public class LoggableClass {

			public Type ClassType { get; set; }
			public LoggableItem LoggableItems { get; set; }
			public string Name => ClassType.Name;

		}

	}

}