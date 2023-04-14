using System;
using UnityEngine;

public class CheckAdsFull : MonoBehaviour
{
	private void Awake()
	{
		if (CheckAdsFull.instance == null)
		{
			CheckAdsFull.instance = this;
		}
		else if (CheckAdsFull.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
		
		}
	}

	public static CheckAdsFull instance;
}
