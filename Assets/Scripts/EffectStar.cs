using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EffectStar : MonoBehaviour
{
	private void OnEnable()
	{
		this.Reset();
	}

	public void Reset()
	{
		this.end1 = true;
		this.end2 = true;
		this.img.sprite = this.starOff;
		if (this.startPos != Vector3.zero)
		{
			this.rectTransform.position = this.startPos;
			this.rectTransform.rotation = Quaternion.identity;
		}
	}

	private void Start()
	{
		this.startPos = this.rectTransform.position;
		this.endPos = this.startPos + new Vector3(0f, 0.8f, 0f);
	}

	public void Win()
	{
		this.end1 = false;
		this.end2 = false;
		this.img.sprite = this.starOn;
		base.StartCoroutine(this.SetAnim());
	}

	private IEnumerator SetAnim()
	{
		while (!this.end2)
		{
			this.rectTransform.Rotate(Vector3.back * 10f);
			if (!this.end1)
			{
				this.rectTransform.position = Vector3.MoveTowards(this.rectTransform.position, this.endPos, 2f * Time.deltaTime);
				if (this.rectTransform.position == this.endPos)
				{
					this.end1 = true;
				}
			}
			if (this.end1 && !this.end2)
			{
				this.rectTransform.position = Vector3.MoveTowards(this.rectTransform.position, this.startPos, 2f * Time.deltaTime);
				if (this.rectTransform.position == this.startPos)
				{
					this.end2 = true;
					this.rectTransform.rotation = Quaternion.identity;
				}
			}
			yield return null;
		}
		yield break;
	}

	public RectTransform rectTransform;

	public Image img;

	public Sprite starOn;

	public Sprite starOff;

	private Vector3 startPos;

	private Vector3 endPos;

	private bool end1;

	private bool end2;
}
