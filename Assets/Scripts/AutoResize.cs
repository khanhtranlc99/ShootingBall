using System;
using UnityEngine;

public class AutoResize : MonoBehaviour
{
	private void Start()
	{
		Camera main = Camera.main;
		float aspect = main.aspect;
		if (main.aspect < 0.5625f)
		{
			float orthographicSize = main.orthographicSize;
			float orthographicSize2 = this.expectedFieldWidth * (float)Screen.height / (float)Screen.width;
			main.orthographicSize = orthographicSize2;
		}
	}

	[SerializeField]
	private float expectedFieldWidth;
}
