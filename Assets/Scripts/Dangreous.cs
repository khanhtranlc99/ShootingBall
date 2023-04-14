using System;
using UnityEngine;

public class Dangreous : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "block")
		{
			this.showAnim.SetActive(true);
			ControlSound.instance.PlaySoundWarning();
		}

	
	}

	public GameObject showAnim;
}
