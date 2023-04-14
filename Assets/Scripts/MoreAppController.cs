using System;
using System.Collections;
using com.F4A.MobileThird;
using MoreApp;
using UnityEngine;

public class MoreAppController : MonoBehaviour
{
	private void Awake()
	{
		if (MoreAppController.instance != null)
		{
			UnityEngine.Object.DestroyImmediate(base.gameObject);
		}
		else
		{
			MoreAppController.instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private void Start()
	{
		base.StartCoroutine(this.load());
	}

	private IEnumerator load()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("appId", this.AppID);
		WWW www = new WWW("http://sonatanhtrang.com/product/index.php/Global_advertise/get_android_ad", wwwform);
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			UnityEngine.Debug.Log("Load moreapp failed");
			this.isLoaded = false;
		}
		else
		{
			Parse parse = new Parse(www.text);
			this.adsinfo = parse.GetAdsInfo();
			base.Invoke("LoadSprite", 0.5f);
			this.isLoaded = true;
		}
		yield break;
	}

	private void LoadSprite()
	{
		if (this.adsinfo.smart_more_app.big_ad != null)
		{
			base.StartCoroutine(this.adsinfo.smart_more_app.big_ad.LoadSprite());
		}
		for (int i = 0; i < this.adsinfo.smart_more_app.small_ad.Count; i++)
		{
			base.StartCoroutine(this.adsinfo.smart_more_app.small_ad[i].LoadSprite());
		}
		if (this.adsinfo.more_app != null)
		{
			base.StartCoroutine(this.adsinfo.more_app.LoadSprite());
		}
	}

	public void ShowSmartMoreApp()
	{
		if (this.isLoaded)
		{
			this.SmartMoreApp.SetActive(true);
			MoreAppController.isShowing = true;
		}
	}

	public void HideSmartMoreApp()
	{
		MoreAppController.isShowing = false;
		this.SmartMoreApp.SetActive(false);
		EventsManager.Instance.LogEvent("close_more_app");
	}

	public static MoreAppController instance;

	public GameObject SmartMoreApp;

	public string AppID;

	public AdsInfo adsinfo;

	public AdsItem[] adsItems;

	public bool isLoaded;

	public static bool isShowing;

	private const string Url = "http://sonatanhtrang.com/product/index.php/Global_advertise/get_android_ad";
}
