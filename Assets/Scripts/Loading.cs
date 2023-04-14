using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	private void OnEnable()
	{
		base.StartCoroutine(this.WaitLoad());
	}

	private IEnumerator WaitLoad()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(1);
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}
}
