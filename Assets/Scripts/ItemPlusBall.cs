using System;
using UnityEngine;

public class ItemPlusBall : MonoBehaviour
{
	private void OnEnable()
	{
		this.active = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!this.active && collision.gameObject.layer == 9)
		{
			GameControll.keysDim[this.stt] = 0;
			GameControll.totalBall++;
			BallControll.ballEndShow++;
			GameObject pooledObject = ObjectPoolerManager.Instance.effectPlusBallPooler.GetPooledObject();
			pooledObject.transform.position = base.transform.position;
			pooledObject.SetActive(true);
			this.active = true;
			ControlSound.instance.PlaySoundPlusBall();
			base.gameObject.SetActive(false);
		}
		if (collision.gameObject.layer == 17)
		{
			base.gameObject.SetActive(false);
		}
	}

	public Rigidbody2D rgb;

	private bool active;

	[HideInInspector]
	public int stt;
}
