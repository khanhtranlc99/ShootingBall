using System;
using UnityEngine;

public class InsideItemXoay : MonoBehaviour
{
	private void Update()
	{
		base.transform.Rotate(Vector3.forward * 800f * Time.deltaTime);
	}
}
