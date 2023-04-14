using System;
using System.Collections.Generic;
using com.F4A.MobileThird;
using MoreApp;
using UnityEngine;
using UnityEngine.UI;

public class AdsItem : MonoBehaviour
{
	public void ImageClick()
	{
		if (!string.IsNullOrEmpty(this.AppStoreUrl))
		{
			Application.OpenURL(this.AppStoreUrl);
			EventsManager.Instance.LogEvent("click_more_app", new Dictionary<string, object>
			{
				{
					"app_link",
					this.AppStoreUrl
				}
			});
		}
	}

	private void Update()
	{
		if (!this.isdone)
		{
			if (this.isLoaded)
			{
				this.Loading.SetActive(false);
				this.isdone = true;
			}
			else
			{
				this.CheckIndex();
			}
		}
	}

	private void CheckIndex()
	{
		if (this.imageindex == 0 && MoreAppController.instance.adsinfo.smart_more_app.big_ad != null && MoreAppController.instance.adsinfo.smart_more_app.big_ad.sprite != null)
		{
			this.SetInfo(MoreAppController.instance.adsinfo.smart_more_app.big_ad);
		}
		else if (this.imageindex < 3 && this.imageindex > 0 && MoreAppController.instance.adsinfo.smart_more_app.small_ad.Count > this.imageindex - 1 && MoreAppController.instance.adsinfo.smart_more_app.small_ad[this.imageindex - 1].sprite != null)
		{
			this.SetInfo(MoreAppController.instance.adsinfo.smart_more_app.small_ad[this.imageindex - 1]);
		}
		else if (this.imageindex == 3 && MoreAppController.instance.adsinfo.more_app != null && MoreAppController.instance.adsinfo.more_app.sprite != null)
		{
			this.SetInfo(MoreAppController.instance.adsinfo.more_app);
		}
	}

	private void SetInfo(AdsItemType2 ads)
	{
		this.isLoaded = true;
		this.AppImage.sprite = ads.sprite;
		this.AppStoreUrl = ads.storeUrl;
		this.download.gameObject.SetActive(true);
	}

	public GameObject Loading;

	public Image download;

	public Image AppImage;

	public string AppStoreUrl;

	public Text AppTitle;

	public Text AppDescription;

	public int imageindex;

	public bool isLoaded;

	private bool isdone;
}
