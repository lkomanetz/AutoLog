//TODO(Logan) -> Implement details for creating a class dynamically.
using AutoLogger.Contracts;
using System;
using System.Linq;
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
			List<OpCode> opCodes = new List<OpCode>();
			IList<BehaviorAttribute> customAttributes = method.GetCustomAttributes()
				.Where(x => x is BehaviorAttribute)
				.Cast<BehaviorAttribute>()
				.ToList();

			//TODO(Logan) -> Actually generate OpCodes for a method.
			return opCodes;
		}

		private TypeBuilder GetTypeBuilder() {
			var typeSignature = "MyDynamicType";
			var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
			var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
				assemblyName, AssemblyBuilderAccess.Run
			);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
			return moduleBuilder.DefineType(
				typeSignature,
				TypeAttributes.Public |
				TypeAttributes.Class |
				TypeAttributes.AutoClass |
				TypeAttributes.AnsiClass |
				TypeAttributes.BeforeFieldInit |
				TypeAttributes.AutoLayout,
				null
			);	
		}

	}

}