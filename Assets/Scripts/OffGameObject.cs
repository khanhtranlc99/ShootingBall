using System;
using System.Collections;
using UnityEngine;

public class OffGameObject : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.offTime)
		{
			base.StartCoroutine(this.OffObject());
		}
		if (this.lazer && GameUtilsOld.Sound)
		{
			this.audioLazer.Play();
		}
	}

	private IEnumerator OffObject()
	{
		yield return new WaitForSeconds(this.timeOff);
		this.Off();
		yield break;
	}

	public void Off()
	{
		base.gameObject.SetActive(false);
	}

	public bool lazer;

	public AudioSource audioLazer;

	public bool offTime;

	public float timeOff;
}
