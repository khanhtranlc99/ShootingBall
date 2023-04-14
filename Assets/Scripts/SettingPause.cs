using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingPause : MonoBehaviour
{
	private void OnEnable()
	{
		bool flag = GameUtils.Sound;
		if (!flag)
		{
			if (!flag)
			{
				this.imgSound.sprite = this.soundOff;
				this.textSound.text = "Sound Off";
			}
		}
		else
		{
			this.imgSound.sprite = this.soundOn;
			this.textSound.text = "Sound On";
		}
	}

	public void ButSound()
	{
		ControlSound.instance.PlaySoundButton();
		bool flag = GameUtils.Sound;
		if (!flag)
		{
			if (!flag)
			{
				this.imgSound.sprite = this.soundOn;
				this.textSound.text = "Sound On";
				ControlSound.instance.OnSound();
				GameUtils.Sound = true;
			}
		}
		else
		{
			this.imgSound.sprite = this.soundOff;
			this.textSound.text = "Sound Off";
			ControlSound.instance.OffSound();
			GameUtils.Sound = false;
		}
	}

	public void ButHowtoPlay()
	{
		ControlSound.instance.PlaySoundButton();
		this.panelHowtoPlay.SetActive(true);
	}

	public void ButRetry()
	{
       
        ControlSound.instance.PlaySoundButton();
		this.panelBackToRetry.SetActive(true);
	}

	public void ButContinue()
	{
		
        ControlSound.instance.PlaySoundButton();
		BackDeviceGame.status = 0;
		Time.timeScale = 1f;
		base.gameObject.SetActive(false);
	}

	public void ButtonMenu()
	{
		this.panelBackToMenu.SetActive(true);
	}

	public Sprite soundOn;

	public Sprite soundOff;

	public Text textSound;

	public Image imgSound;

	public GameObject panelHowtoPlay;

	public GameObject panelBackToRetry;

	public GameObject panelBackToMenu;
}
