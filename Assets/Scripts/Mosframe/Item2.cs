using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mosframe
{
	public class Item2 : UIBehaviour, IDynamicScrollViewItem
	{
		public void onUpdateItem(int index)
		{
			if (RealTimeInsertItemExample.data.Count > index)
			{
				this.title.text = RealTimeInsertItemExample.data[index].name + "(" + index.ToString("000") + ")";
				this.background.color = this.colors[Mathf.Abs(index) % this.colors.Length];
				this.icon.sprite = Resources.Load<Sprite>((Mathf.Abs(index) % 20 + 1).ToString("icon_00"));
			}
		}

		private readonly Color[] colors = new Color[]
		{
			Color.cyan,
			Color.green
		};

		public Image icon;

		public Text title;

		public Image background;
	}
}
