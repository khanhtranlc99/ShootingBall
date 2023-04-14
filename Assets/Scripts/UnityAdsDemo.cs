using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnityAdsDemo : MonoBehaviour
{
	//private IEnumerator ShowAdWhenReady()
	//{
	//	while (!Advertisement.IsReady())
	//	{
	//		yield return null;
	//	}
	//	Advertisement.Show();
	//	yield break;
	//}

	//private void Awake()
	//{
	//	Advertisement.Initialize(this.ANDROID_GAME_ID, true);
	//}

	public void ShowAds()
	{
		//base.StartCoroutine(this.ShowAdsWhenReady(string.Empty));
	}

	//private IEnumerator ShowAdsWhenReady(string zone = "")
	//{
	//	while (!Advertisement.IsReady(zone))
	//	{
	//		yield return null;
	//	}
	//	ShowOptions options = new ShowOptions();
	//	options.resultCallback = new Action<ShowResult>(this.AdCallbackhandler);
	//	if (Advertisement.IsReady(zone))
	//	{
	//		Advertisement.Show(zone, options);
	//	}
	//	yield break;
	//}

	public void ShowAd(string zone = "")
	{
		//if (string.Equals(zone, string.Empty))
		//{
		//	zone = null;
		//}
		//ShowOptions showOptions = new ShowOptions();
		//showOptions.resultCallback = new Action<ShowResult>(this.AdCallbackhandler);
		//if (Advertisement.IsReady(zone))
		//{
		//	Advertisement.Show(zone, showOptions);
		//}
	}

	//private void AdCallbackhandler(ShowResult result)
	//{
	//	if (result != ShowResult.Failed)
	//	{
	//		if (result != ShowResult.Skipped)
	//		{
	//			if (result == ShowResult.Finished)
	//			{
	//				UnityEngine.Debug.Log("Ad Finished. Rewarding player...");
	//				this.coins += this.coinsBonus;
	//				this.coinTxt.text = this.coins.ToString();
	//			}
	//		}
	//		else
	//		{
	//			UnityEngine.Debug.Log("Ad skipped. Son, I am dissapointed in you");
	//		}
	//	}
	//	else
	//	{
	//		UnityEngine.Debug.Log("I swear this has never happened to me before");
	//	}
	//}

	//private IEnumerator WaitForAd()
	//{
	//	float currentTimeScale = Time.timeScale;
	//	Time.timeScale = 0f;
	//	yield return null;
	//	while (Advertisement.isShowing)
	//	{
	//		yield return null;
	//	}
	//	Time.timeScale = currentTimeScale;
	//	yield break;
	//}

	public string ANDROID_GAME_ID = "73390";

	public string IOS_GAME_ID;

	private int coins;

	public int coinsBonus = 5;

	public Text coinTxt;
}
