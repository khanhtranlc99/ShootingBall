using System;
using UnityEngine;

public class TestMoreApp : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			if (this.moreAppView.activeSelf)
			{
				this.moreAppView.SetActive(false);
			}
			else
			{
				Application.Quit();
			}
		}
	}

	public void ShowMoreApp()
	{
		MoreAppController.instance.ShowSmartMoreApp();
		TestMoreApp.isShowedMoreAppInHome = true;
	}

	public static bool isShowedMoreAppInHome;

	public GameObject moreAppView;

	public bool allowMoreAppAppearManyTime;
}
