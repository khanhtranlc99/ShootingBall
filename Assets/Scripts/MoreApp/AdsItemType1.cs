using System;
using System.Collections;
using UnityEngine;

namespace MoreApp
{
	[Serializable]
	public class AdsItemType1
	{
		public IEnumerator LoadSprite()
		{
			if (!string.IsNullOrEmpty(this.imageUrl))
			{
				WWW www = new WWW(this.imageUrl);
				yield return www;
				if (string.IsNullOrEmpty(www.error))
				{
					Texture2D texture2D = new Texture2D(1, 1);
					www.LoadImageIntoTexture(texture2D);
					Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
					this.sprite = sprite;
				}
				else
				{
					UnityEngine.Debug.Log(www.error);
				}
			}
			yield return null;
			yield break;
		}

		public string storeUrl = string.Empty;

		public string imageUrl = string.Empty;

		public Sprite sprite;
	}
}
