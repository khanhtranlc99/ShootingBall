using System;
using UnityEngine;

namespace Mosframe
{
	public static class RectTransformEx
	{
		public static RectTransform setFullSize(this RectTransform self)
		{
			self.sizeDelta = new Vector2(0f, 0f);
			self.anchorMin = new Vector2(0f, 0f);
			self.anchorMax = new Vector2(1f, 1f);
			self.pivot = new Vector2(0.5f, 0.5f);
			return self;
		}

		public static Vector2 getSize(this RectTransform self)
		{
			return self.rect.size;
		}

		public static void setSize(this RectTransform self, Vector2 newSize)
		{
			Vector2 pivot = self.pivot;
			Vector2 vector = newSize - self.rect.size;
			self.offsetMin -= new Vector2(vector.x * pivot.x, vector.y * pivot.y);
			self.offsetMax += new Vector2(vector.x * (1f - pivot.x), vector.y * (1f - pivot.y));
		}

		public static RectTransform setSizeFromLeft(this RectTransform self, float rate)
		{
			self.setFullSize();
			float width = self.rect.width;
			self.anchorMin = new Vector2(0f, 0f);
			self.anchorMax = new Vector2(0f, 1f);
			self.pivot = new Vector2(0f, 1f);
			self.sizeDelta = new Vector2(width * rate, 0f);
			return self;
		}

		public static RectTransform setSizeFromRight(this RectTransform self, float rate)
		{
			self.setFullSize();
			float width = self.rect.width;
			self.anchorMin = new Vector2(1f, 0f);
			self.anchorMax = new Vector2(1f, 1f);
			self.pivot = new Vector2(1f, 1f);
			self.sizeDelta = new Vector2(width * rate, 0f);
			return self;
		}

		public static RectTransform setSizeFromTop(this RectTransform self, float rate)
		{
			self.setFullSize();
			float height = self.rect.height;
			self.anchorMin = new Vector2(0f, 1f);
			self.anchorMax = new Vector2(1f, 1f);
			self.pivot = new Vector2(0f, 1f);
			self.sizeDelta = new Vector2(0f, height * rate);
			return self;
		}

		public static RectTransform setSizeFromBottom(this RectTransform self, float rate)
		{
			self.setFullSize();
			float height = self.rect.height;
			self.anchorMin = new Vector2(0f, 0f);
			self.anchorMax = new Vector2(1f, 0f);
			self.pivot = new Vector2(0f, 0f);
			self.sizeDelta = new Vector2(0f, height * rate);
			return self;
		}

		public static void setOffset(this RectTransform self, float left, float top, float right, float bottom)
		{
			self.offsetMin = new Vector2(left, top);
			self.offsetMax = new Vector2(right, bottom);
		}

		public static bool inScreenRect(this RectTransform self, Vector2 screenPos)
		{
			Canvas componentInParent = self.GetComponentInParent<Canvas>();
			RenderMode renderMode = componentInParent.renderMode;
			if (renderMode != RenderMode.ScreenSpaceCamera)
			{
				if (renderMode == RenderMode.ScreenSpaceOverlay)
				{
					return RectTransformUtility.RectangleContainsScreenPoint(self, screenPos);
				}
				if (renderMode == RenderMode.WorldSpace)
				{
					return RectTransformUtility.RectangleContainsScreenPoint(self, screenPos);
				}
			}
			else
			{
				Camera worldCamera = componentInParent.worldCamera;
				if (worldCamera != null)
				{
					return RectTransformUtility.RectangleContainsScreenPoint(self, screenPos, worldCamera);
				}
			}
			return false;
		}

		public static bool inScreenRect(this RectTransform self, RectTransform rectTransform)
		{
			Rect screenRect = self.getScreenRect();
			Rect screenRect2 = rectTransform.getScreenRect();
			return screenRect.Overlaps(screenRect2);
		}

		public static Rect getScreenRect(this RectTransform self)
		{
			Rect result = default(Rect);
			Canvas componentInParent = self.GetComponentInParent<Canvas>();
			Camera worldCamera = componentInParent.worldCamera;
			if (worldCamera != null)
			{
				Vector3[] array = new Vector3[4];
				self.GetWorldCorners(array);
				result.min = worldCamera.WorldToScreenPoint(array[0]);
				result.max = worldCamera.WorldToScreenPoint(array[2]);
			}
			return result;
		}
	}
}
