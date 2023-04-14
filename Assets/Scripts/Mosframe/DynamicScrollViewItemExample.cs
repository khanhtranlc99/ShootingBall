using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mosframe
{
	public class DynamicScrollViewItemExample : UIBehaviour, IDynamicScrollViewItem
	{
		public void onUpdateItem(int index)
		{
			if (index % 2 == 0)
			{
				for (int i = 0; i < this.selectLevel.Length; i++)
				{
					this.selectLevel[i].SetData(i + 1 + index * 5);
				}
			}
			else
			{
				for (int j = 0; j < this.selectLevel.Length; j++)
				{
					this.selectLevel[j].SetData(5 - j + index * 5);
				}
			}
		}

		private readonly Color[] colors = new Color[]
		{
			Color.cyan,
			Color.green
		};

		public Text title;

		public Image background;

		public SelectLevel[] selectLevel;
	}
}
