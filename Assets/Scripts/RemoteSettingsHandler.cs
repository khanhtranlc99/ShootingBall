using System;
using UnityEngine;

public class RemoteSettingsHandler : MonoBehaviour
{
	private void Awake()
	{
		RemoteSettingsHandler.remoteSettingsHandler = this;
	}

	private void Start()
	{
		//RemoteSettings.Updated += this.HandleRemoteUpdate;
		//this.HandleRemoteUpdate();
	}

	private void HandleRemoteUpdate()
	{
		this.display_home_ads = RemoteSettings.GetBool("display_home_ads", true);
		this.display_banner_ads = RemoteSettings.GetBool("display_banner_ads", true);
		this.display_interstitial_ads = RemoteSettings.GetBool("display_interstitial_ads", true);
		this.display_video_ads = RemoteSettings.GetBool("display_video_ads", true);
		this.delay_interstital_time = RemoteSettings.GetFloat("delay_interstital_time", this.delay_interstital_time);
		this.admob_banner_ratio = RemoteSettings.GetInt("admob_banner_ratio", this.admob_banner_ratio);
		this.fan_banner_ratio = RemoteSettings.GetInt("fan_banner_ratio", this.fan_banner_ratio);
		this.admob_interstitial_ratio = RemoteSettings.GetInt("admob_interstitial_ratio", this.admob_interstitial_ratio);
		this.fan_interstitial_ratio = RemoteSettings.GetInt("fan_interstitial_ratio", this.fan_interstitial_ratio);
		this.ball_bonus = RemoteSettings.GetInt("ball_bonus", 0);
		this.admob_ratio = RemoteSettings.GetInt("admob_ratio", this.admob_ratio);
		this.richadx_ratio = RemoteSettings.GetInt("richadx_ratio", this.richadx_ratio);
		this.inters_ads_before_ratio = RemoteSettings.GetInt("inters_ads_before_ratio", this.inters_ads_before_ratio);
		this.inters_ads_after_ratio = RemoteSettings.GetInt("inters_ads_after_ratio", this.inters_ads_after_ratio);
	}

	public static RemoteSettingsHandler remoteSettingsHandler;

	public int inters_ads_before_ratio = 50;

	public int inters_ads_after_ratio = 50;

	public bool display_home_ads = true;

	public bool display_banner_ads = true;

	public bool display_interstitial_ads = true;

	public bool display_video_ads = true;

	public float delay_interstital_time = 5f;

	public int admob_banner_ratio = 50;

	public int fan_banner_ratio = 50;

	public int admob_interstitial_ratio = 50;

	public int fan_interstitial_ratio = 50;

	public int ball_bonus;

	public int admob_ratio = 50;

	public int richadx_ratio = 50;
}
