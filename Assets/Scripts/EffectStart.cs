using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class EffectStart : MonoBehaviour
{
	private void OnEnable()
	{
		base.StartCoroutine(this.OffGameObject());
		//this.skeletonAnimation.state.SetAnimation(0, this.anim, false);
	}

	private IEnumerator OffGameObject()
	{
		yield return new WaitForSeconds(2f);
		base.gameObject.SetActive(false);
		yield break;
	}

	public SkeletonAnimation skeletonAnimation;

	[SpineAnimation("", "", true, false)]
	public string anim;
}
