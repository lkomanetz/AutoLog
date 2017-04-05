using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public class DependencyContainer {

		private Dictionary<Type, Type> _someDictionary;

		public DependencyContainer() {
		}

		public void Register<TKey, TConcrete>() {
			Type concrete;
			if (!_someDictionary.TryGetValue(typeof(TKey), out concrete)) {

			}
			_someDictionary.Add(typeof(TKey), typeof(TConcrete));
		}

		public object Resolve<TKey>() {
			throw new NotImplementedException();
		}

	}

}