using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mosframe
{
	[RequireComponent(typeof(ScrollRect))]
	public abstract class DynamicScrollView : UIBehaviour
	{
		protected abstract float contentAnchoredPosition { get; set; }

		protected abstract float contentSize { get; }

		protected abstract float viewportSize { get; }

		protected override void Awake()
		{
			if (this.itemPrototype == null)
			{
				UnityEngine.Debug.LogError(RichText.red(new
				{
					base.name,
					this.itemPrototype
				}));
				return;
			}
			base.Awake();
			ScrollRect component = base.GetComponent<ScrollRect>();
			this._viewportRect = component.viewport;
			this._contentRect = component.content;
		}

		protected override void Start()
		{
			this.itemPrototype.gameObject.SetActive(false);
			this._prevTotalItemCount = this.totalItemCount;
			int num = (int)(this.viewportSize / this._itemSize) + 3;
			for (int i = 0; i <= num; i++)
			{
				RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(this.itemPrototype);
				rectTransform.SetParent(this._contentRect, false);
				rectTransform.name = i.ToString();
				rectTransform.anchoredPosition = ((this._direction == DynamicScrollView.Direction.Vertical) ? new Vector2(0f, this._itemSize * (float)i) : new Vector2(this._itemSize * (float)i, 0f));
				this._containers.AddLast(rectTransform);
				rectTransform.gameObject.SetActive(true);
				this.updateItem(i, rectTransform.gameObject);
			}
			this.resizeContent();
			this.MoveLevelPlaying();
		}

		private void MoveLevelPlaying()
		{
			int @int = PlayerPrefs.GetInt("b");
			int num = @int / 5 - 1;
			this.contentAnchoredPosition = (float)num * this._itemSize;
		}

		private void Update()
		{
			if (this.totalItemCount != this._prevTotalItemCount)
			{
				this._prevTotalItemCount = this.totalItemCount;
				bool flag = false;
				if (this.viewportSize - this.contentAnchoredPosition >= this.contentSize - this._itemSize * 0.5f)
				{
					flag = true;
				}
				this.resizeContent();
				if (flag)
				{
					this.contentAnchoredPosition = this.viewportSize - this.contentSize;
				}
				this.refresh();
			}
			while (this.contentAnchoredPosition - this._prevAnchoredPosition < this._itemSize)
			{
				this._prevAnchoredPosition -= this._itemSize;
				RectTransform value = this._containers.Last.Value;
				this._containers.RemoveLast();
				this._containers.AddFirst(value);
				float num = this._itemSize * (float)this._nextInsertItemNo;
				value.anchoredPosition = ((this._direction == DynamicScrollView.Direction.Vertical) ? new Vector2(0f, num) : new Vector2(num, 0f));
				this.updateItem(this._nextInsertItemNo, value.gameObject);
				this._nextInsertItemNo--;
			}
			while (this.contentAnchoredPosition - this._prevAnchoredPosition > this._itemSize * 2f)
			{
				this._prevAnchoredPosition += this._itemSize;
				RectTransform value2 = this._containers.First.Value;
				this._containers.RemoveFirst();
				this._containers.AddLast(value2);
				float num2 = this._itemSize * (float)(this._containers.Count + this._nextInsertItemNo);
				value2.anchoredPosition = ((this._direction == DynamicScrollView.Direction.Vertical) ? new Vector2(0f, num2) : new Vector2(num2, 0f));
				this.updateItem(this._containers.Count + this._nextInsertItemNo, value2.gameObject);
				this._nextInsertItemNo++;
			}
		}

		public void insertItem()
		{
		}

		private void refresh()
		{
			int num = 0;
			if (this.contentAnchoredPosition != 0f)
			{
				num = (int)(-this.contentAnchoredPosition / this._itemSize);
			}
			foreach (RectTransform rectTransform in this._containers)
			{
				float num2 = this._itemSize * (float)num;
				rectTransform.anchoredPosition = ((this._direction == DynamicScrollView.Direction.Vertical) ? new Vector2(0f, num2) : new Vector2(num2, 0f));
				this.updateItem(num, rectTransform.gameObject);
				num++;
			}
			this._nextInsertItemNo = num - this._containers.Count;
			this._prevAnchoredPosition = (float)((int)(this.contentAnchoredPosition / this._itemSize)) * this._itemSize;
		}

		private void resizeContent()
		{
			Vector2 size = this._contentRect.getSize();
			if (this._direction == DynamicScrollView.Direction.Vertical)
			{
				size.y = this._itemSize * (float)this.totalItemCount;
			}
			else
			{
				size.x = this._itemSize * (float)this.totalItemCount;
			}
			this._contentRect.setSize(size);
		}

		private void updateItem(int index, GameObject itemObj)
		{
			if (index < 0 || index >= this.totalItemCount)
			{
				itemObj.SetActive(false);
			}
			else
			{
				itemObj.SetActive(true);
				IDynamicScrollViewItem component = itemObj.GetComponent<IDynamicScrollViewItem>();
				if (component != null)
				{
					component.onUpdateItem(index);
				}
			}
		}

		public int totalItemCount = 99;

		public RectTransform itemPrototype;

		protected DynamicScrollView.Direction _direction;

		protected LinkedList<RectTransform> _containers = new LinkedList<RectTransform>();

		protected float _prevAnchoredPosition;

		protected int _nextInsertItemNo;

		protected float _itemSize = -1f;

		protected int _prevTotalItemCount = 99;

		protected RectTransform _viewportRect;

		protected RectTransform _contentRect;

		public enum Direction
		{
			Vertical,
			Horizontal
		}
	}
}
