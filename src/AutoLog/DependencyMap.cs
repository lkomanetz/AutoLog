using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoLogger {

	public class DependencyMap {

		private readonly Dictionary<Type, Func<object>> _dependencyMap;

		public DependencyMap() {
			_dependencyMap = new Dictionary<Type, Func<object>>();
		}

		public void Register<TKey, TConcrete>() where TConcrete : TKey {
			_dependencyMap[typeof(TKey)] = () => ResolveByType(typeof(TConcrete));
		}

		public void Register<T>(T instance) {
			_dependencyMap[typeof(T)] = () => instance;
		}

		public TKey Resolve<TKey>() {
			return (TKey)Resolve(typeof(TKey));
		}

		public object Resolve(Type t) {
			if (_dependencyMap.TryGetValue(t, out var provider)) {
				return provider.Invoke();
			}

			return ResolveByType(t);
		}

		private object ResolveByType(Type type) {
			ConstructorInfo ctor = GetConstructorInfoFor(type);
			if (ctor == null) {
				return null;
			}
			
			var parameters = ctor.GetParameters()
				.Select(p => Resolve(p.ParameterType))
				.ToArray();

			return ctor.Invoke(parameters);
		}

		private ConstructorInfo GetConstructorInfoFor(Type type) {
			int constructorCount = type.GetTypeInfo().DeclaredConstructors.Count();
			ConstructorInfo ctor = null;

			if (constructorCount > 1) {
				ctor = type.GetTypeInfo().DeclaredConstructors
					.Aggregate((cA, cB) => cA.GetParameters().Length > cB.GetParameters().Length ? cA : cB);
			}
			else {
				ctor = type.GetTypeInfo().DeclaredConstructors.SingleOrDefault();
			}

			return ctor;
		}

	}

}