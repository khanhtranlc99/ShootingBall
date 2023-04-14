using System;
using UnityEngine;
using UnityEngine.UI;

public class HowtoPlay : MonoBehaviour
{
	private void OnEnable()
	{
		this.state = 1;
		this.imgSlide.sprite = this.tut1;
		this.text.text = "1/9";
		this.butPrevious.SetActive(false);
		BackDeviceGame.status = 7;
	}

	public void ButClose()
	{
		ControlSound.instance.PlaySoundButton();
		BackDeviceGame.status = 2;
		base.gameObject.SetActive(false);
	}

	public void ButNext()
	{
		ControlSound.instance.PlaySoundButton();
		switch (this.state)
		{
		case 1:
			this.state = 2;
			this.imgSlide.sprite = this.tut2;
			this.text.text = "2/9";
			this.butPrevious.SetActive(true);
			break;
		case 2:
			this.state = 3;
			this.imgSlide.sprite = this.tut3;
			this.text.text = "3/9";
			break;
		case 3:
			this.state = 4;
			this.imgSlide.sprite = this.tut4;
			this.text.text = "4/9";
			break;
		case 4:
			this.state = 5;
			this.imgSlide.sprite = this.tut5;
			this.text.text = "5/9";
			break;
		case 5:
			this.state = 6;
			this.imgSlide.sprite = this.tut6;
			this.text.text = "6/9";
			break;
		case 6:
			this.state = 7;
			this.imgSlide.sprite = this.tut7;
			this.text.text = "7/9";
			break;
		case 7:
			this.state = 8;
			this.imgSlide.sprite = this.tut8;
			this.text.text = "8/9";
			break;
		case 8:
			this.state = 9;
			this.imgSlide.sprite = this.tut9;
			this.text.text = "9/9";
			this.butNext.SetActive(false);
			break;
		}
	}

	public void ButPrevious()
	{
		ControlSound.instance.PlaySoundButton();
		switch (this.state)
		{
		case 2:
			this.state = 1;
			this.imgSlide.sprite = this.tut1;
			this.text.text = "1/9";
			this.butPrevious.SetActive(false);
			break;
		case 3:
			this.state = 2;
			this.imgSlide.sprite = this.tut2;
			this.text.text = "2/9";
			break;
		case 4:
			this.state = 3;
			this.imgSlide.sprite = this.tut3;
			this.text.text = "3/9";
			break;
		case 5:
			this.state = 4;
			this.imgSlide.sprite = this.tut4;
			this.text.text = "4/9";
			break;
		case 6:
			this.state = 5;
			this.imgSlide.sprite = this.tut5;
			this.text.text = "5/9";
			break;
		case 7:
			this.state = 6;
			this.imgSlide.sprite = this.tut6;
			this.text.text = "6/9";
			break;
		case 8:
			this.state = 7;
			this.imgSlide.sprite = this.tut7;
			this.text.text = "7/9";
			break;
		case 9:
			this.state = 8;
			this.imgSlide.sprite = this.tut8;
			this.text.text = "8/9";
			this.butNext.SetActive(true);
			break;
		}
	}

	public Image imgSlide;

	public Text text;

	public GameObject butPrevious;

	public GameObject butNext;

	public Sprite tut1;

	public Sprite tut2;

	public Sprite tut3;

	public Sprite tut4;

	public Sprite tut5;

	public Sprite tut6;

	public Sprite tut7;

	public Sprite tut8;

	public Sprite tut9;

	private int state;
}
