using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;
using UnityEngine.Events;

public class GameScene : MonoBehaviour
{

    public Text tvCoin;
    public void Start()
    {
        tvCoin.text = "" + UseProfile.Coin;
        EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.CHANGE_COIN, ChangeCoin);
    }
    private void ChangeCoin(object param)
    {
        tvCoin.text = "" + UseProfile.Coin;
    }
}
