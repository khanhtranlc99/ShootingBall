using System;
using UnityEngine;

public class ItemXoay : MonoBehaviour
{
	private void OnEnable()
	{
		this.active = false;
		BallControll.eventEndTurn += this.EndTurn;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 17)
		{
			base.gameObject.SetActive(false);
		}
		if (collision.gameObject.layer == 9)
		{
			this.active = true;
		}
	}

	private void EndTurn()
	{
		if (this.active)
		{
			GameControll.keysDim[this.stt] = 0;
			BallControll.eventEndTurn -= this.EndTurn;
			base.gameObject.SetActive(false);
		}
	}

	private bool active;

	private Vector2 force;

	[HideInInspector]
	public int stt;
}
