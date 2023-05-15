using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	private string sceneName;
	private void OnEnable()
	{
		base.StartCoroutine(this.WaitLoad());
	}

	private IEnumerator WaitLoad()
	{
	
		sceneName = "Game";
		var _asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		while (!_asyncOperation.isDone)
		{
			yield return null;
		}
		yield break;
	}
}
