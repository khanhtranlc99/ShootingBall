using System;
using UnityEngine;

public class BackDeviceGame : MonoBehaviour
{
	private void Awake()
	{
		BackDeviceGame.status = 0;
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			switch (BackDeviceGame.status)
			{
			case 0:
				this.gameControll.ButtonPause();
				BackDeviceGame.status = 2;
				break;
			case 1:
				MoreAppController.instance.HideSmartMoreApp();
				BackDeviceGame.status = 0;
				break;
			case 2:
				this.settingPause.ButContinue();
				BackDeviceGame.status = 0;
				break;
			case 3:
				this.controlEndgame.ButtonClose();
				break;
			case 4:
				this.controlContinue.ButtonClose();
				break;
			case 5:
				this.backToRetry.ButNo();
				BackDeviceGame.status = 2;
				break;
			case 6:
				this.backToMenu.ButtonNo();
				BackDeviceGame.status = 2;
				break;
			case 7:
				this.howToPlay.ButClose();
				BackDeviceGame.status = 2;
				break;
			}
		}
	}

	public static int status;

	public GameControll gameControll;

	public SettingPause settingPause;

	public ControlEndgame controlEndgame;

	public ControlContinue controlContinue;

	public BackToMenu backToMenu;

	public BackToRetry backToRetry;

	public HowtoPlay howToPlay;
}
