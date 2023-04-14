using System;
using UnityEngine;

public class ItemLaser : MonoBehaviour
{
	private void OnEnable()
	{
		this.active = false;
		BallControll.eventEndTurn += this.EndTurn;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 9)
		{
			this.active = true;
			ControlSound.instance.PlaySoundLazer();
			this.anim.Play("lazerCross");
			if (this.horizontal)
			{
				this.LaserHorizontal();
			}
			if (this.vertical)
			{
				this.LaserVertical();
			}
			if (this.cross)
			{
				this.LaserHorizontal();
				this.LaserVertical();
			}
		}
		if (collision.gameObject.layer == 17)
		{
			base.gameObject.SetActive(false);
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

	private void LaserHorizontal()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectLazerHorizontalPooler.GetPooledObject();
		pooledObject.transform.position = new Vector3(0f, base.transform.position.y, 0f);
		pooledObject.SetActive(true);
	}

	private void LaserVertical()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectLazerVerticalPooler.GetPooledObject();
		pooledObject.transform.position = new Vector3(base.transform.position.x, 0.59f, 0f);
		pooledObject.SetActive(true);
	}

	public Animator anim;

	public bool horizontal;

	public bool vertical;

	public bool cross;

	private bool active;

	[HideInInspector]
	public int stt;
}
