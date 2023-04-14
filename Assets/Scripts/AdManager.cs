using System;
using UnityEngine;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
	private void Start()
	{
		this.adLoaded = false;
		this.LoadAd();
	}

	public bool IsAdLoaded()
	{
		return this.adLoaded;
	}

	public void LoadAd()
	{
	}

	public GameObject targetAdObject;

	public Button targetButton;

	private bool adLoaded;
}
