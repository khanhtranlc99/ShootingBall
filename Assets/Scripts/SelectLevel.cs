using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
	public void SetData(int index)
	{
		this.level = index;
		this.txtLevel.text = index.ToString();
		if (index <= SelectLevel.levelUnlock)
		{
			this.imgLock.gameObject.SetActive(false);
			this.button.enabled = true;
			for (int i = 0; i < this.stars.Length; i++)
			{
				this.stars[i].gameObject.SetActive(true);
				this.stars[i].sprite = this.starOff;
			}
			int @int = PlayerPrefs.GetInt(index.ToString(), 0);
			for (int j = 0; j < @int; j++)
			{
				this.stars[j].sprite = this.starOn;
			}
		}
		else
		{
			this.imgLock.gameObject.SetActive(true);
			this.button.enabled = false;
			for (int k = 0; k < this.stars.Length; k++)
			{
				this.stars[k].gameObject.SetActive(false);
			}
		}
		if (index == SelectLevel.levelUnlock)
		{
			this.effect.SetActive(true);
		}
		else
		{
			this.effect.SetActive(false);
		}
	}

	public void Level()
	{
		ControlSound.instance.PlaySoundButton();
		GameControll.levelPlaying = this.level;
		this.panelLoading.SetActive(true);
	}

	public GameObject panelLoading;

	public Text txtLevel;

	public Image imgLock;

	public Image[] stars;

	public Sprite starOn;

	public Sprite starOff;

	public Button button;

	public GameObject effect;

	public static int levelUnlock;

	private int level;
}
