using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
//using GoogleMobileAds.Common;



//  ----------------------------------------------
//  Author:     CuongCT <caothecuong91@gmail.com> 
//  Copyright (c) 2016 OneSoft JSC
// ----------------------------------------------

public class AdmobAds : MonoBehaviour
{

    [SerializeField] private AdsController ironsourceController;
    [SerializeField] public GoogleAdmobe googleAdmobe;



    public float countdownAds;

    public void Init()
    {
        
        countdownAds = 1000;
        googleAdmobe.InitAds();

      
    }

    #region Interstitial
    public bool ShowInterstitial(bool isShowImmediatly = false, string actionWatchLog = "other", Action actionIniterClose = null, UnityAction actionIniterShow = null, string level = null)
    {
        if (GameController.Instance.useProfile.IsRemoveAds)
        {
            actionIniterClose?.Invoke();
            return false;
        }
        if (GameControll.levelPlaying > RemoteConfigController.GetFloatConfig(FirebaseConfig.LEVEL_START_SHOW_INITSTIALL, 2))
        {
          

            if (countdownAds > RemoteConfigController.GetFloatConfig(FirebaseConfig.DELAY_SHOW_INITSTIALL, 30) || isShowImmediatly)
            {
                googleAdmobe.ShowInterstitial22(actionIniterClose);
            }

        }
        else
        {
            if (actionIniterClose != null)
                actionIniterClose();
        }
        return true;
    }

    #endregion

    #region Video Reward

    /// <summary>
    /// Xử lý Show Video
    /// </summary>
    /// <param name="actionReward">Hành động khi xem xong Video và nhận thưởng </param>
    /// <param name="actionNotLoadedVideo"> Hành động báo lỗi không có video để xem </param>
    /// <param name="actionClose"> Hành động khi đóng video (Đóng lúc đang xem dở hoặc đã xem hết) </param>
    public void ShowVideoReward(Action actionReward)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
           
            //GameController.Instance.AnalyticsController.LogWatchVideo(actionType, true, false, level);
            return;
        }
        googleAdmobe.ShowRewardedVideo222(actionReward);
        //if (!ironsourceController.ShowRewardedVideo(actionNotLoadedVideo, () =>
        //{
        //    actionReward?.Invoke();
        //    countdownAds = 0;
        //    GameController.Instance.AnalyticsController.LogVideoRewardShow(actionType.ToString());
        //}))
        //{
        //    actionNotLoadedVideo?.Invoke();
        //}
    }

    #endregion

    #region Banner
    public void ShowBanner()
    {
        //ironsourceController.ShowBanner();
        //googleAdmobe.ShowBanner();
    }

    public void DestroyBanner()
    {
        //googleAdmobe.HideBanner();
    }
    #endregion

    private void Update()
    {
        countdownAds += Time.unscaledDeltaTime;
    }
    //public void OnAppStateChanged(AppState state)
    //{
    //    if (state == AppState.Foreground)
    //    {
    //        // COMPLETE: Show an app open ad if available.
    //        AppOpenAdManager.Instance.ShowAdIfAvailable();
    //    }
    //}
}
