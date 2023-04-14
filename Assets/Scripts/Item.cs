using System;
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.none)
		{
			this.SetColor();
		}
		this.ShowValue();
	}

	private void Bom()
	{
		if (this.horizontal)
		{
			this.HorizontalBom();
		}
		if (this.vertical)
		{
			this.VerticalBom();
		}
		if (this.cross)
		{
			this.HorizontalBom();
			this.VerticalBom();
		}
		if (this.square)
		{
			this.SquareBom();
		}
		GameControll.keysDim[this.stt] = 0;
		GameControll.instane.CalculateScore();
		GameObject pooledObject = ObjectPoolerManager.Instance.brokenPooler.GetPooledObject();
		pooledObject.transform.position = base.transform.position;
		pooledObject.SetActive(true);
		base.gameObject.SetActive(false);
	}

	private IEnumerator OffGameobjectByBoom()
	{
		yield return new WaitForSeconds(0.8f);
		base.gameObject.SetActive(false);
		yield break;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		this.TakeDamage();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int layer = collision.gameObject.layer;
		if (layer != 17)
		{
			if (layer != 13)
			{
				if (layer == 18)
				{
					this.TakeDamage();
				}
			}
			else
			{
				this.Bom();
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private void TakeDamage()
	{
		this.value--;
		this.GetEffect();
		if (GameControll.keysDim[this.stt] == 2)
		{
			GameControll.keysDim[this.stt] = 1;
		}
		GameControll.valuesDim[this.stt] = this.value;
		ControlSound.instance.PlaySoundTouchItem();
		if (this.value <= 0)
		{
			GameControll.keysDim[this.stt] = 0;
			if (this.horizontal)
			{
				ControlSound.instance.PlaySoundBoom();
				this.HorizontalBom();
			}
			if (this.vertical)
			{
				ControlSound.instance.PlaySoundBoom();
				this.VerticalBom();
			}
			if (this.cross)
			{
				ControlSound.instance.PlaySoundBoom();
				this.HorizontalBom();
				this.VerticalBom();
			}
			if (this.square)
			{
				ControlSound.instance.PlaySoundBoom();
				this.SquareBom();
			}
			GameControll.instane.CalculateScore();
			GameObject pooledObject = ObjectPoolerManager.Instance.brokenPooler.GetPooledObject();
			pooledObject.transform.position = base.transform.position;
			pooledObject.SetActive(true);
			base.gameObject.SetActive(false);
		}
		if (this.none)
		{
			this.SetColor();
		}
		this.ShowValue();
	}
	public void HandleBoosterThunder(int dame)
	{
		this.value -= dame;
		this.GetEffect();
		if (GameControll.keysDim[this.stt] == 2)
		{
			GameControll.keysDim[this.stt] = 1;
		}
		GameControll.valuesDim[this.stt] = this.value;
		ControlSound.instance.PlaySoundTouchItem();
		if (this.value <= 0)
		{
			GameControll.keysDim[this.stt] = 0;
			if (this.horizontal)
			{
				ControlSound.instance.PlaySoundBoom();
				this.HorizontalBom();
			}
			if (this.vertical)
			{
				ControlSound.instance.PlaySoundBoom();
				this.VerticalBom();
			}
			if (this.cross)
			{
				ControlSound.instance.PlaySoundBoom();
				this.HorizontalBom();
				this.VerticalBom();
			}
			if (this.square)
			{
				ControlSound.instance.PlaySoundBoom();
				this.SquareBom();
			}
			GameControll.instane.CalculateScore();
			GameObject pooledObject = ObjectPoolerManager.Instance.brokenPooler.GetPooledObject();
			pooledObject.transform.position = base.transform.position;
			pooledObject.SetActive(true);
			base.gameObject.SetActive(false);
		}
		if (this.none)
		{
			this.SetColor();
		}
		this.ShowValue();
	}

	private void GetEffect()
	{
		if (this.effectSquare)
		{
			GameObject pooledObject = ObjectPoolerManager.Instance.effectTouchSquarePooler.GetPooledObject();
			pooledObject.transform.position = base.transform.position;
			pooledObject.SetActive(true);
		}
		if (this.effectTgbl)
		{
			GameObject pooledObject2 = ObjectPoolerManager.Instance.effectTouchTgblPlooer.GetPooledObject();
			pooledObject2.transform.position = base.transform.position;
			pooledObject2.SetActive(true);
		}
		if (this.effectTgbr)
		{
			GameObject pooledObject3 = ObjectPoolerManager.Instance.effectTouchTgbrPooler.GetPooledObject();
			pooledObject3.transform.position = base.transform.position;
			pooledObject3.SetActive(true);
		}
		if (this.effectTgtl)
		{
			GameObject pooledObject4 = ObjectPoolerManager.Instance.effectTouchTgtlPlooer.GetPooledObject();
			pooledObject4.transform.position = base.transform.position;
			pooledObject4.SetActive(true);
		}
		if (this.effectTgtr)
		{
			GameObject pooledObject5 = ObjectPoolerManager.Instance.effectTouchTgtrPooler.GetPooledObject();
			pooledObject5.transform.position = base.transform.position;
			pooledObject5.SetActive(true);
		}
	}

	private void HorizontalBom()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectBoomHorizontalPooler.GetPooledObject();
		pooledObject.transform.position = new Vector3(0f, base.transform.position.y, 0f);
		pooledObject.SetActive(true);
	}

	private void VerticalBom()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectBoomVerticalPooler.GetPooledObject();
		pooledObject.transform.position = new Vector3(base.transform.position.x, 0.59f, 0f);
		pooledObject.SetActive(true);
	}

	private void SquareBom()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectBoomSquarePooler.GetPooledObject();
		pooledObject.transform.position = base.transform.position;
		pooledObject.SetActive(true);
	}

	private void SetColor()
	{
		this.colorValue = this.value % 8;
		switch (this.colorValue)
		{
		case 0:
			this.sprite.sprite = this.red;
			break;
		case 1:
			this.sprite.sprite = this.blue;
			break;
		case 2:
			this.sprite.sprite = this.green;
			break;
		case 3:
			this.sprite.sprite = this.purple;
			break;
		case 4:
			this.sprite.sprite = this.orange;
			break;
		case 5:
			this.sprite.sprite = this.pink;
			break;
		case 6:
			this.sprite.sprite = this.lightYellow;
			break;
		case 7:
			this.sprite.sprite = this.yellow;
			break;
		}
	}

	private void ShowValue()
	{
		this.text.text = this.value.ToString();
	}

	[HideInInspector]
	public int value;

	public Sprite blue;

	public Sprite green;

	public Sprite lightYellow;

	public Sprite purple;

	public Sprite red;

	public Sprite yellow;

	public Sprite orange;

	public Sprite pink;

	[HideInInspector]
	public int stt;

	public SpriteRenderer sprite;

	public TextMesh text;

	[Header("TypeBoom")]
	public bool none;

	public bool horizontal;

	public bool vertical;

	public bool cross;

	public bool square;

	[Header("TypeEffect")]
	public bool effectSquare;

	public bool effectTgtl;

	public bool effectTgtr;

	public bool effectTgbl;

	public bool effectTgbr;

	private int colorValue;
}
