using System;
using System.Collections;
using UnityEngine;

public class BrokenControl : MonoBehaviour
{
	private void OnEnable()
	{
		base.StartCoroutine(this.OffObject());
	}

	private IEnumerator OffObject()
	{
		yield return new WaitForSeconds(1f);
		base.gameObject.SetActive(false);
		yield break;
	}
}
