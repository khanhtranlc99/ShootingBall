using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SuggetBox : BaseBox
{
    #region instance
    private static SuggetBox instance;
    public static SuggetBox Setup(GiftType giftType, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<SuggetBox>(PathPrefabs.SUGGET_BOX));
            instance.Init();
        }

        instance.InitState(giftType);
        return instance;
    }
    #endregion

    #region  Var 
    [SerializeField] private GiftType giftType;
    [SerializeField] private  Button btnClose;
    [SerializeField] private Button btnWatch;
    [SerializeField] private Button btnCoin;
    [SerializeField] private  Image imgGift;
    [SerializeField] private  Text txtGift;

    [SerializeField] private Text textCoin;


    #endregion


    private void Init()
    {
        btnClose.onClick.AddListener(delegate {  Close(); });
        btnWatch.onClick.AddListener(delegate {  OnButtonWatchClick(); });
        btnCoin.onClick.AddListener(delegate {  OnButtonCoinClick(); });
        
    }
    private void InitState(GiftType paramGiftType)
    {
           switch (paramGiftType)
            {
                case GiftType.ThunderBooster:
                    giftType = paramGiftType;
                    imgGift.sprite = GameController.Instance.dataContain.giftDatabase.GetIconItem(GiftType.ThunderBooster);
                imgGift.SetNativeSize();
                    txtGift.text = "x1";
                    break;
                case GiftType.AddBallBooster:
                    giftType = paramGiftType;
                    imgGift.sprite = GameController.Instance.dataContain.giftDatabase.GetIconItem(GiftType.AddBallBooster);
                imgGift.SetNativeSize();
                txtGift.text = "x1";
                    break;
            }

        textCoin.text = "" + UseProfile.Coin;


    }


    private void OnButtonWatchClick()
    {
      
        GameController.Instance.admobAds.ShowVideoReward(
                 delegate { HandleTakeGift(); });
    }
    private void OnButtonCoinClick()
    {
        if(UseProfile.Coin >= 600)
        {
            UseProfile.Coin -= 600;
            HandleTakeGift();

        }
        else
        {
            ShopBox.Setup().Show();
        }
    }
    
    
    private  void HandleTakeGift()
    {
        switch (giftType)    
           {
               case GiftType.ThunderBooster:
                   UseProfile.ThunderBooster += 1;
                   break;
               case GiftType.AddBallBooster:
                   UseProfile.AddBallsBooster += 1;
                   break;
           }
        Close();
    }
    
}
