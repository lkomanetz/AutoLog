using System;

namespace AutoLogger {
	namespace Contracts {

		[Flags]
		public enum LoggableItem {

			Nothing = 0,
			PublicMethods = 1,
			InternalMethods = 2,
			PrivateMethods = 4

		}

	}

}