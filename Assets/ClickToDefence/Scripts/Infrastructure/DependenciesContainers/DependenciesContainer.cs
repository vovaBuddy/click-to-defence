using System;
using System.Collections.Generic;

namespace ClickToDefence.Scripts.Infrastructure.DependenciesContainers
{
	public class DependenciesContainer<TDependency>
	{
		private readonly Dictionary<Type, TDependency> dependencies = new Dictionary<Type, TDependency>();

		public void Register<T>(T dependency) where T : TDependency
		{
			dependencies.Add(typeof(T), dependency);
		}

		public T Resolve<T>() where T : TDependency
		{
			return (T) dependencies[typeof(T)];
		}
	}
}