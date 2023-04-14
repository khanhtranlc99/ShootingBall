using com.F4A.MobileThird;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlEndgame : MonoBehaviour
{
	private void OnEnable()
	{
	
		BackDeviceGame.status = 3;
		bool flag = ControlEndgame.win;
		if (flag)
		{
			if (flag)
			{
				ControlSound.instance.PlaySoundWin();
				this.imgStatus.sprite = this.spriteComplete;
				this.butNext.SetActive(true);
				this.butReplay.SetActive(false);
				this.animStatus.enabled = true;
				int star = GameControll.instane.star;
				if (star != 1)
				{
					if (star != 2)
					{
						if (star == 3)
						{
							this.unitStar = 3;
						}
					}
					else
					{
						this.unitStar = 2;
					}
				}
				else
				{
					this.unitStar = 1;
				}
				base.StartCoroutine(this.AnimStar());
				int @int = PlayerPrefs.GetInt(GameControll.levelPlaying.ToString());
				if (@int < GameControll.instane.star)
				{
					PlayerPrefs.SetInt(GameControll.levelPlaying.ToString(), GameControll.instane.star);
				}
				EventsManager.Instance.LogEvent("game_win", new Dictionary<string, object>
				{
					{
						"level_number",
						GameControll.levelPlaying
					}
				});
			}
		}
		else
		{
			ControlSound.instance.PlaySoundEndGameFail();
			this.imgStatus.sprite = this.spriteFail;
			this.butNext.SetActive(false);
			this.butReplay.SetActive(true);
			this.animStatus.enabled = false;
			EventsManager.Instance.LogEvent("game_lose", new Dictionary<string, object>
			{
				{
					"level_number",
					GameControll.levelPlaying
				}
			});
		}
		this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
	}
    private void OnDisable()
    {
		GameControll.instane.addBall.color = new Color32(255,255,255,255);
		GameControll.instane.wasUseAddBall = false;
	}

    public static void SetEndGame()
	{
		int @int = PlayerPrefs.GetInt(GameControll.levelPlaying.ToString());
		if (@int < GameControll.instane.star)
		{
			PlayerPrefs.SetInt(GameControll.levelPlaying.ToString(), GameControll.instane.star);
		}
		EventsManager.Instance.LogEvent("game_win", new Dictionary<string, object>
		{
			{
				"level_number",
				GameControll.levelPlaying
			}
		});
	}

	private IEnumerator AnimStar()
	{
		for (int i = 0; i < this.unitStar; i++)
		{
			yield return new WaitForSeconds(0.5f);
			this.effectStar[i].Win();
		}
		yield break;
	}

	public void ButtonClose()
	{
		ControlSound.instance.PlaySoundButton();
		ObjectPoolerManager.Instance.OffAllObject();
		ObjectPoolerManager.Instance.gameObject.transform.position = Vector3.zero;
		if (GameControll.instane.placementIntersAds == GameControll.PlacementIntersAds.AFTER)
		{
			//SG_AdManager.ads.ShowIntertitial();
			base.StartCoroutine(this.CallSceneMenu(0.2f));
		}
		else
		{
			base.StartCoroutine(this.CallSceneMenu(0f));
		}
	}

	public void ButtonRetry()
	{
		ControlSound.instance.PlaySoundButton();
		ObjectPoolerManager.Instance.gameObject.transform.position = Vector3.zero;
		ObjectPoolerManager.Instance.OffAllObject();
		GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
		if (GameControll.instane.placementIntersAds == GameControll.PlacementIntersAds.AFTER)
		{
			//SG_AdManager.ads.ShowIntertitial();
			base.StartCoroutine(this.CallNewLevel(0.2f));
		}
		else
		{
			base.StartCoroutine(this.CallNewLevel(0f));
		}
	}

	public void ButtonNext()
	{
		ControlSound.instance.PlaySoundButton();
		ObjectPoolerManager.Instance.gameObject.transform.position = Vector3.zero;
		ObjectPoolerManager.Instance.OffAllObject();
		GameControll.levelPlaying++;
		GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
		if (GameControll.instane.placementIntersAds == GameControll.PlacementIntersAds.AFTER)
		{
			//SG_AdManager.ads.ShowIntertitial();
			base.StartCoroutine(this.CallNewLevel(0.2f));
		}
		else
		{
			base.StartCoroutine(this.CallNewLevel(0f));
		}
	}

	private IEnumerator CallNewLevel(float time)
	{
		yield return new WaitForSeconds(time);
		GameControll.instane.StartPlay();
		base.gameObject.SetActive(false);
		yield break;
	}

	private IEnumerator CallSceneMenu(float time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(0);
		yield break;
	}

	public static bool win;

	public Image imgStatus;

	public Text txtStage;

	public GameObject butNext;

	public GameObject butReplay;

	public Sprite spriteComplete;

	public Sprite spriteFail;

	public EffectStar[] effectStar;

	public Animator animStatus;

	private int unitStar;
}
