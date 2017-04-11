//TODO(Logan) -> Implement details for creating a class dynamically.
using AutoLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoLogger {

	internal class ClassBuilder {

		public ClassBuilder() { }

		public object Build(LoggableClass classToBuild) {
			return null;
		}

		internal IList<OpCode> GenerateOpCodes(MethodInfo method) {
			throw new NotImplementedException();	
		}
	}

}