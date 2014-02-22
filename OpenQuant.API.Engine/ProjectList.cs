using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API.Engine
{
	public class ProjectList : IEnumerable
	{
		private Dictionary<string, Project> projects;
		public int Count
		{
			get
			{
				return this.projects.Count;
			}
		}
		public Project this[string name]
		{
			get
			{
				return this.projects[name];
			}
		}
		public Project this[int index]
		{
			get
			{
				int num = 0;
				foreach (Project current in this.projects.Values)
				{
					if (num == index)
					{
						return current;
					}
					num++;
				}
				throw new IndexOutOfRangeException("Project with specified index does not exist");
			}
		}
		public IEnumerator GetEnumerator()
		{
			return this.projects.Values.GetEnumerator();
		}
		internal ProjectList(List<Project> list)
		{
			this.projects = new Dictionary<string, Project>();
			foreach (Project current in list)
			{
				this.projects[current.Name] = current;
			}
		}
		public bool Contains(string name)
		{
			return this.projects.ContainsKey(name);
		}
		public bool TryGetValue(string name, out Project project)
		{
			return this.projects.TryGetValue(name, out project);
		}
	}
}
