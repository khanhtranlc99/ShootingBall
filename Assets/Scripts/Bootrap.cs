using System;
using UnityEngine;

public class Bootrap : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
