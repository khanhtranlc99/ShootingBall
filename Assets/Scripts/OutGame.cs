using System;
using UnityEngine;

public class OutGame : MonoBehaviour
{
	public void OnEnable()
	{
		BackDeviceStart.status = 1;
	}

	public void ButtonNo()
	{
		ControlSound.instance.PlaySoundButton();
		BackDeviceStart.status = 0;
		base.gameObject.SetActive(false);
	}

	public void ButtonYes()
	{
		ControlSound.instance.PlaySoundButton();
		Application.Quit();
	}
}
