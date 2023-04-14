using System;
using UnityEngine;

public class WallControl : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		this.anim.Play("wallFlicker");
	}

	public Animator anim;
}
