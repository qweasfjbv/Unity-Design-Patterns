using System.Collections.Generic;
using UnityEngine;

namespace Patterns.StructuralPatterns.Composite
{
	public interface IMenuElement
	{
		void Draw();
	}

	public class MenuItem : IMenuElement
	{
		private string label;

		public MenuItem(string label)
		{
			this.label = label;
		}

		public void Draw()
		{
			Debug.Log($"Drawing Menu Item : {label}");
		}
	}

	public class MenuGroup : IMenuElement
	{
		private string groupName;
		private List<IMenuElement> children = new();

		public MenuGroup(string groupName)
		{
			this.groupName = groupName;
		}

		public void Add(IMenuElement element)
		{
			children.Add(element);
		}

		public void Draw()
		{
			Debug.Log($"Drawing Group : {groupName}");
			for(int i = 0; i < children.Count; i++)
			{
				children[i].Draw();
			}
		}
	}

}