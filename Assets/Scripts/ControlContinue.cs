using com.F4A.MobileThird;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlContinue : MonoBehaviour
{
	private void OnEnable()
	{
		BackDeviceGame.status = 4;
		this.timeBuyRuby = this.timeBuyRubyStart;
		EventsManager.Instance.LogEvent("game_out_of_move", new Dictionary<string, object>
        {
            {
                "level_number",
                GameControll.levelPlaying
            }
        });
	}

	private void Update()
	{
		this.timeBuyRuby -= Time.deltaTime;
		this.imgTimeRun.fillAmount = this.timeBuyRuby / this.timeBuyRubyStart;
		if (this.timeBuyRuby <= 0f)
		{
			//SG_AdManager.ads.ShowIntertitial();
			ControlEndgame.win = false;
			base.StartCoroutine(this.ShowEndGame());
		}
	}

	public void ButtonClose()
	{
		if (GameControll.instane.placementIntersAds == GameControll.PlacementIntersAds.BEFORE)
		{
			//SG_AdManager.ads.ShowIntertitial();
		}
		ControlSound.instance.PlaySoundButton();
		ControlEndgame.win = false;
		base.StartCoroutine(this.ShowEndGame());
	}

	public void ButtonContinue()
	{
		EventsManager.Instance.LogEvent("watch_video");
		GameControll.finishAdsVideo = true;
		ControlSound.instance.PlaySoundButton();
		
		BackDeviceGame.status = 10;
	}

	public IEnumerator ShowEndGame()
	{
		yield return new WaitForSeconds(0.1f);
		this.panelEndgame.SetActive(true);
		base.gameObject.SetActive(false);
		yield break;
	}

	public GameObject panelEndgame;

	public float timeBuyRubyStart;

	public Image imgTimeRun;

	public GameObject boomContinue;

	private float timeBuyRuby;
}
