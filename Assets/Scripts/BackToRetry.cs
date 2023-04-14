using System;
using UnityEngine;

public class BackToRetry : MonoBehaviour
{
	private void OnEnable()
	{
		BackDeviceGame.status = 5;
	}

	public void ButNo()
	{
		BackDeviceGame.status = 2;
		base.gameObject.SetActive(false);
	}

	public void ButYes()
	{
		Time.timeScale = 1f;
		//SG_AdManager.ads.ShowIntertitial();
		ControlSound.instance.PlaySoundButton();
		ObjectPoolerManager.Instance.OffAllObject();
		ObjectPoolerManager.Instance.gameObject.transform.position = Vector3.zero;
		GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
		GameControll.instane.StartPlay();
		BackDeviceGame.status = 0;
		this.panelPause.SetActive(false);
		base.gameObject.SetActive(false);
	}

	public GameObject panelPause;
}
