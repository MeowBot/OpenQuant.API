using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API.Engine
{
	public class ProjectInfoList : IEnumerable
	{
		private Dictionary<string, ProjectInfo> projects;
		public int Count
		{
			get
			{
				return this.projects.Count;
			}
		}
		public ProjectInfo this[string name]
		{
			get
			{
				return this.projects[name];
			}
		}
		public ProjectInfo this[int index]
		{
			get
			{
				int num = 0;
				foreach (ProjectInfo current in this.projects.Values)
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
		internal ProjectInfoList(List<ProjectInfo> list)
		{
			this.projects = new Dictionary<string, ProjectInfo>();
			foreach (ProjectInfo current in list)
			{
				this.projects[current.Name] = current;
			}
		}
		public bool Contains(string name)
		{
			return this.projects.ContainsKey(name);
		}
		public bool TryGetValue(string name, out ProjectInfo project)
		{
			return this.projects.TryGetValue(name, out project);
		}
	}
}
