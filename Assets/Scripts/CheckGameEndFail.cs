using System;
using System.Collections;
using UnityEngine;

public class CheckGameEndFail : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 10)
		{
			PlayerPrefs.SetInt("j", 0);
			this.dangreous.SetActive(false);
			ControlSound.instance.PlaySoundTouchBottom();
			if (!CheckGameEndFail.checkWatchedVideos )
			{
				this.panelContinue.SetActive(true);
			}
			else
			{
				BackDeviceGame.status = 10;
				ControlEndgame.win = false;
                //if (GameControll.instane.placementIntersAds == GameControll.PlacementIntersAds.BEFORE)
                //{
                //	SG_AdManager.ads.ShowIntertitial();
                //	base.StartCoroutine(this.ShowEndgame(0.3f));
                //}
                //else
                //{
                //	base.StartCoroutine(this.ShowEndgame(0f));
                //}

              
                base.StartCoroutine(this.ShowEndgame(0.3f));
            }
		}
	}

	private IEnumerator ShowEndgame(float time)
	{
		yield return new WaitForSeconds(time);
		this.panelEndgame.SetActive(true);
		yield break;
	}

	public GameObject panelContinue;

	public GameObject panelEndgame;

	public GameObject dangreous;

	public static bool checkWatchedVideos;
}
