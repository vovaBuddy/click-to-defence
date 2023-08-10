using System;
using System.Collections.Generic;

namespace ClickToDefence.Scripts.Infrastructure.DependenciesContainers
{
	public class DependenciesContainer<TDependency>
	{
		private readonly Dictionary<Type, TDependency> dependencies = new Dictionary<Type, TDependency>();

		public void Register(TDependency dependency)
		{
			dependencies.Add(typeof(TDependency), dependency);
		}

		public TDependency Resolve()
		{
			return dependencies[typeof(TDependency)];
		}
	}
}