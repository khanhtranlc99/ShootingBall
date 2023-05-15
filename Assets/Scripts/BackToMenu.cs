using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
	private void OnEnable()
	{
		BackDeviceGame.status = 6;
	}

	public void ButtonNo()
	{
		ControlSound.instance.PlaySoundButton();
		BackDeviceGame.status = 2;
		base.gameObject.SetActive(false);
	}

	public void ButtonYes()
	{
		GameController.Instance.admobAds.googleAdmobe.ShowInterstitial22(delegate {
			Time.timeScale = 1f;
			//SG_AdManager.ads.ShowIntertitial();
			ControlSound.instance.PlaySoundButton();
			ObjectPoolerManager.Instance.OffAllObject();
			SceneManager.LoadScene("Start");
		});
			
	}
}
