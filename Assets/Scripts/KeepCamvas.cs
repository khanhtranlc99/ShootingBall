using System;
using UnityEngine;

public class KeepCamvas : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public Canvas canvas;
}
