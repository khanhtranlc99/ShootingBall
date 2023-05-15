using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using GoogleMobileAds.Api.Mediation.UnityAds;
using GoogleMobileAds.Api;
using UnityEngine.Events;
public class GoogleAdmobe : MonoBehaviour
{
    public static GoogleAdmobe Instance;
    private Action<bool> acInterClosed, acRewarded;

    #region Admob
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    private BannerView bannerView;
    public UnityEvent OnAdLoadedEvent;
    [HideInInspector]
    public UnityEvent OnAdFailedToLoadEvent;
    [HideInInspector]
    public UnityEvent OnAdOpeningEvent;
    [HideInInspector]
    public UnityEvent OnAdFailedToShowEvent;
    [HideInInspector]
    public UnityEvent OnUserEarnedRewardEvent;
    [HideInInspector]
    public UnityEvent OnAdClosedEvent;
    #endregion
    public const string BANNER_ID = "ca-app-pub-8063947267674831/4748858596";
    public const string INTERS_ID = "ca-app-pub-8063947267674831/8605215266";
    public const string VIDEO_ID = "ca-app-pub-8063947267674831/2674231734";


    public void InitAds()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            HandleInitCompleteAction(initStatus);
        });

       // ShowBannerAd();
     //   ShowBannerAdAdmob();
        //   UnityAds.SetGDPRConsentMetaData(true);
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.LogError("Initialization complete.");
      
        InitInterstitial();
        InitRewarded();

    }

    public void RequestBannerAd()
    {
        //PrintStatus("Requesting Banner ad.");

        // These ad units are configured to always serve test ads.
       string adUnitId = BANNER_ID;
 

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) =>
        {
            //PrintStatus("Banner ad loaded.");
            OnAdLoadedEvent.Invoke();
        };
        bannerView.OnAdFailedToLoad += (sender, args) =>
        {
            // PrintStatus("Banner ad failed to load with error: " + args.LoadAdError.GetMessage());
            OnAdFailedToLoadEvent.Invoke();
        };
        bannerView.OnAdOpening += (sender, args) =>
        {
            //PrintStatus("Banner ad opening.");
            OnAdOpeningEvent.Invoke();
        };
        bannerView.OnAdClosed += (sender, args) =>
        {
            //PrintStatus("Banner ad closed.");
            OnAdClosedEvent.Invoke();
        };
        bannerView.OnPaidEvent += (sender, args) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Banner ad received a paid event.",
                                        args.AdValue.CurrencyCode,
                                        args.AdValue.Value);
            //PrintStatus(msg);
        };

        // Load a banner ad
        bannerView.LoadAd(CreateRequest());
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }

    public void ShowBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Show();
        }
    }

    public void HideBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Hide();
        }
    }


    private bool IsIntersLoaded()
    {
        return interstitial.IsLoaded();
    }

    public bool IsRewardLoaded()
    {
        return rewardedAd.IsLoaded();
    }
    public void ShowInterstitial(Action<bool> _ac)
    {
        if (!GameController.Instance.useProfile.IsRemoveAds)
        {
            if (IsIntersLoaded())
            {
                acInterClosed = _ac;
                interstitial.Show();

            }
            else
            {
                interstitial.LoadAd(CreateRequest());
                if (acInterClosed != null)
                    acInterClosed(true);
            }
        }
    }
    public Action actionCloseInter;
    public void ShowInterstitial22(Action callBack)
    {

        if (IsIntersLoaded())
        {
            
            interstitial.Show();
            actionCloseInter = callBack;
        }
        else
        {
            interstitial.LoadAd(CreateRequest());
            callBack?.Invoke();
        }

    }
    public Action actionRewardShowRewarded;
    public void ShowRewardedVideo222(Action callBack)
    {
        if (IsRewardLoaded())
        {


            rewardedAd.Show();
            actionRewardShowRewarded = callBack;
        }
        else
        {

            rewardedAd.LoadAd(CreateRequest());

        }
    }
    public void ShowRewardedVideo(Action<bool> _ac)
    {
        if (IsRewardLoaded())
        {
            Debug.Log("[Ads] Manager realy loaded");
            acRewarded = _ac;
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("[Ads] Manager request");
            rewardedAd.LoadAd(CreateRequest());
            acRewarded(false);
        }
    }


    #region Init Admob
 
    AdRequest CreateRequest()
    {
        //  AdRequest request = new AdRequest.Builder().AddTestDevice("BA730DD6C0C19894C11CB7FDF6D75AA8").AddTestDevice("D96EFB8D3BB99E5B5CAF739EB1EB5E9D").AddTestDevice("256FC58E8184F47CC4E7BE3570B2AC3B").Build();
        AdRequest request = new AdRequest.Builder().Build();
        return request;
    }
   
    void InitInterstitial()
    {
        interstitial = new InterstitialAd(INTERS_ID);
        interstitial.OnAdOpening += Interstitial_OnAdOpening;
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdFailedToLoad += HandleLoadFail;
        interstitial.LoadAd(CreateRequest());

    }

    private void HandleLoadFail(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError("========load fail ads=======");
    }

    private void Interstitial_OnAdOpening(object sender, EventArgs e)
    {
        //    MyAnalytic.EventShowInter();
    }

    void InitRewarded()
    {
        this.rewardedAd = new RewardedAd(VIDEO_ID);
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        this.rewardedAd.LoadAd(CreateRequest());
    }



    #region Handler
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        actionCloseInter?.Invoke();
        interstitial.LoadAd(CreateRequest());
    }

    private void RewardedAd_OnAdLoaded(object sender, EventArgs e)
    {
        Debug.LogError("====== load video ====");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        if (acRewarded != null)
        {
            acRewarded(false);
        }
        InitRewarded();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        actionRewardShowRewarded?.Invoke();
    }
    AdRequest adRequestAdmob = null;

    public static event Action OnBannerAdLoad = delegate { };
    public static event Action  OnBannerShow = delegate { };
    private void RequestBannerAdmob()
    {


            if(bannerView != null)
            {
            bannerView.OnAdLoaded -= BannerViewAdmob_OnAdLoaded;
            }

            string id = BANNER_ID;

          
            if (!string.IsNullOrEmpty(id))
            {
                Debug.Log("@LOG AdsManager.Admob.RequestBannerAdmob id: " + id);
                AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
            //bannerViewAdmob = new BannerView(id, AdSize.Banner, (AdPosition)adConfigData.AdPosition);
            bannerView = new BannerView(id, adaptiveSize, AdPosition.Top);
        }
            if(bannerView != null)
            {
            bannerView.LoadAd(adRequestAdmob);
            bannerView.OnAdLoaded += BannerViewAdmob_OnAdLoaded;
            }

    }

    private void BannerViewAdmob_OnAdLoaded(object sender, EventArgs e)
    {
        OnBannerAdLoad?.Invoke();
    }

    protected bool IsBannerAdAdmobReady()
    {

            if (bannerView != null)
            {
                Debug.Log("@LOG AdsManager.Admob.IsBannerAdAdmobReady");
                return true;
            }

        return false;
    }

    protected bool ShowBannerAdAdmob()
    {

            
                if (bannerView != null)
                {
                 
            bannerView.Show();
            Debug.LogError("@LOG AdsManager.Admob.ShowBannerAdAdmob");
            return true;
                }
                else
                {
            Debug.LogError("False");
            RequestBannerAdmob();
                }
            

        return false;
    }

    protected bool HideBannerAdAdmob()
    {

            
                if (bannerView != null)
                 {
                 bannerView.Hide();
                    return true;
                }
            

        return false;
    }

    protected bool DestroyBannerAdAdmob()
    {

            if ( bannerView != null)
            {
            bannerView.Hide();
            bannerView.Destroy();
                return true;
            }

        return false;
    }
    #endregion
    #endregion
}

