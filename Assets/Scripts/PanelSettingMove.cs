using System;
using System.Collections;
using UnityEngine;

public class PanelSettingMove : MonoBehaviour
{
	private void OnEnable()
	{
		base.StartCoroutine(this.MoveIn());
	}

	private IEnumerator MoveIn()
	{
		this.posStart = base.transform.position;
		this.target = base.transform.position - new Vector3(500f, 0f, 0f);
		while (base.transform.position != this.target)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.target, 800f * Time.deltaTime);
			yield return null;
		}
		yield break;
	}

	public void Move()
	{
		base.StartCoroutine(this.MoveOut());
	}

	private IEnumerator MoveOut()
	{
		while (base.transform.position != this.posStart)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.posStart, 800f * Time.deltaTime);
			yield return null;
			if (base.transform.position == this.posStart)
			{
				this.panelSetting.SetActive(false);
			}
		}
		yield break;
	}

	private Vector3 posStart;

	private Vector3 target;

	public GameObject panelSetting;
}
