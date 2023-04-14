using System;
using System.Collections;
using UnityEngine;

public class EffectTouch : MonoBehaviour
{
	private void OnEnable()
	{
		this.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
		base.transform.localScale = Vector3.one;
		this.colora = 1f;
		this.scale = 1f;
		base.StartCoroutine(this.Anim());
	}

	private IEnumerator Anim()
	{
		yield return new WaitForSeconds(0.1f);
		float time = 0f;
		this.colora = 0.9f;
		while (time < this.timeDuration)
		{
			time += Time.deltaTime;
			this.scale = Mathf.Lerp(this.scale, 1.7f, time / this.timeDuration);
			this.colora = Mathf.Lerp(this.colora, 0f, time / this.timeDuration);
			this.spriteRenderer.color = new Color(1f, 1f, 1f, this.colora);
			base.transform.localScale = Vector2.one * this.scale;
			yield return null;
		}
		base.gameObject.SetActive(false);
		yield break;
	}

	public SpriteRenderer spriteRenderer;

	private float colora;

	private float scale;

	public float timeDuration = 1f;
}
