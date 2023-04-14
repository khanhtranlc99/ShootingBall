using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mosframe
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ScrollRect))]
	public class ScrollbarHandleSize : UIBehaviour
	{
		protected override void Awake()
		{
			base.Awake();
			this.scrollRect = base.GetComponent<ScrollRect>();
		}

		protected override void OnEnable()
		{
			this.scrollRect.onValueChanged.AddListener(new UnityAction<Vector2>(this.onValueChanged));
		}

		protected override void OnDisable()
		{
			this.scrollRect.onValueChanged.RemoveListener(new UnityAction<Vector2>(this.onValueChanged));
		}

		public void onValueChanged(Vector2 value)
		{
			Scrollbar horizontalScrollbar = this.scrollRect.horizontalScrollbar;
			if (horizontalScrollbar != null)
			{
				if (horizontalScrollbar.size > this.maxSize)
				{
					horizontalScrollbar.size = this.maxSize;
				}
				else if (horizontalScrollbar.size < this.minSize)
				{
					horizontalScrollbar.size = this.minSize;
				}
			}
			Scrollbar verticalScrollbar = this.scrollRect.verticalScrollbar;
			if (verticalScrollbar != null)
			{
				if (verticalScrollbar.size > this.maxSize)
				{
					verticalScrollbar.size = this.maxSize;
				}
				else if (verticalScrollbar.size < this.minSize)
				{
					verticalScrollbar.size = this.minSize;
				}
			}
		}

		public float maxSize = 1f;

		public float minSize = 0.1f;

		private ScrollRect scrollRect;
	}
}
