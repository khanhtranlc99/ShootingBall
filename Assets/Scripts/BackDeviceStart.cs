using System;
using UnityEngine;

public class BackDeviceStart : MonoBehaviour
{
	private void Awake()
	{
		BackDeviceStart.status = 0;
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			int num = BackDeviceStart.status;
			if (num != 0)
			{
				if (num != 1)
				{
					if (num == 2)
					{
						MoreAppController.instance.HideSmartMoreApp();
						if (this.outGame.gameObject.activeInHierarchy)
						{
							BackDeviceStart.status = 1;
						}
						else
						{
							BackDeviceStart.status = 0;
						}
					}
				}
				else
				{
					this.outGame.ButtonNo();
					BackDeviceStart.status = 0;
				}
			}
			else
			{
				this.startGame.ButtonOutGame();
				BackDeviceStart.status = 1;
			}
		}
	}

	public static int status;

	public StartGame startGame;

	public OutGame outGame;
}
