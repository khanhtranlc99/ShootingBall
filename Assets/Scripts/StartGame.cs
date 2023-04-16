using com.F4A.MobileThird;
using System;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	private void Awake()
	{
#if ENABLE_RESOLUTION
		Screen.SetResolution(1080, 1920, true);
#endif
		this.panelLoading.SetActive(false);
		SelectLevel.levelUnlock = GameUtilsOld.GetUnlockLevel();
	}

	public void ButtonOutGame()
	{
		ControlSound.instance.PlaySoundButton();
		BackDeviceStart.status = 1;
		this.panelOutGame.SetActive(true);
	}

	public void ButtonShop()
	{
		ControlSound.instance.PlaySoundButton();
	}

	public void ButtonBall()
	{
		ControlSound.instance.PlaySoundButton();
	}

	public void ButtonClassic()
	{
		ControlSound.instance.PlaySoundButton();
	}

	public void ButtonMoreGame()
	{
		BackDeviceStart.status = 2;
		SocialManager.Instance.OpenLinkDeveloper();
	}

	public void ButtonSHop()
	{
		ShopBox.Setup().Show();
	}

	public GameObject panelOutGame;

	public GameObject panelLoading;
}
