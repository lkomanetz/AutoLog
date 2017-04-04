using System;

namespace AutoLogger {

	public class ProxyGenerator<T> {
		private Type _typeToProxy;

		public ProxyGenerator() {
			_typeToProxy = typeof(T);
		}

		public Type TypeToProxy => _typeToProxy;

		public T Generate() {
			return default(T);
		}

	}

}