using System;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
	public void Awake()
	{
		if (ControlSound.instance == null)
		{
			ControlSound.instance = this;
		}
		else if (ControlSound.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public void OffSound()
	{
		this.soundStart.mute = true;
		this.soundTouchItem.mute = true;
		this.soundEndGameFail.mute = true;
		this.soundWarning.mute = true;
		this.soundButton.mute = true;
		this.soundWin.mute = true;
		this.soundTouchBottom.mute = true;
		this.soundBoom.mute = true;
		this.soundPlusBall.mute = true;
		this.soundLazer.mute = true;
	}

	public void OnSound()
	{
		this.soundStart.mute = false;
		this.soundTouchItem.mute = false;
		this.soundEndGameFail.mute = false;
		this.soundWarning.mute = false;
		this.soundButton.mute = false;
		this.soundWin.mute = false;
		this.soundTouchBottom.mute = false;
		this.soundBoom.mute = false;
		this.soundPlusBall.mute = false;
		this.soundLazer.mute = false;
	}

	public void PlaySoundLazer()
	{
		if (!this.soundLazer.isPlaying)
		{
			this.soundLazer.Play();
		}
	}

	public void PlaySoundStart()
	{
		this.soundStart.Play();
	}

	public void PlaySoundTouchItem()
	{
		if (!this.soundTouchItem.isPlaying)
		{
			this.soundTouchItem.Play();
		}
	}

	public void PlaySoundEndGameFail()
	{
		this.soundEndGameFail.Play();
	}

	public void PlaySoundWarning()
	{
		this.soundWarning.Play();
	}

	public void PlaySoundButton()
	{
		this.soundButton.Play();
	}

	public void PlaySoundWin()
	{
		this.soundWin.Play();
	}

	public void PlaySoundTouchBottom()
	{
		this.soundTouchBottom.Play();
	}

	public void PlaySoundBoom()
	{
		this.soundBoom.Play();
	}

	public void PlaySoundPlusBall()
	{
		this.soundPlusBall.Play();
	}

	public static ControlSound instance;

	public AudioSource soundStart;

	public AudioSource soundTouchItem;

	public AudioSource soundEndGameFail;

	public AudioSource soundWarning;

	public AudioSource soundButton;

	public AudioSource soundWin;

	public AudioSource soundTouchBottom;

	public AudioSource soundBoom;

	public AudioSource soundPlusBall;

	public AudioSource soundLazer;
}
