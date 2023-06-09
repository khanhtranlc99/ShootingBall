using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingStart : MonoBehaviour
{
	private void OnEnable()
	{
		bool sound = GameUtilsOld.Sound;
		if (!sound)
		{
			if (!sound)
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

	public void ButtonSound()
	{
		ControlSound.instance.PlaySoundButton();
		bool sound = GameUtilsOld.Sound;
		if (!sound)
		{
			if (!sound)
			{
				this.imgSound.sprite = this.soundOn;
				this.textSound.text = "Sound On";
				ControlSound.instance.OnSound();
				GameUtilsOld.Sound = true;
			}
		}
		else
		{
			this.imgSound.sprite = this.soundOff;
			this.textSound.text = "Sound Off";
			ControlSound.instance.OffSound();
			GameUtilsOld.Sound = false;
		}
	}

	public void ButtonClose()
	{
		base.gameObject.SetActive(false);
	}

	public Image imgSound;

	public Text textSound;

	public Sprite soundOn;

	public Sprite soundOff;
}