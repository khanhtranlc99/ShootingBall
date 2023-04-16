using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif


public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [HideInInspector] public MoneyEffectController moneyEffectController;
    [HideInInspector] public UseProfile useProfile;
    public DataContain dataContain;
    public MusicManager musicManager;
    public AdmobAds admobAds;
    public AnalyticsController AnalyticsController;
    public IapControllerBase iapController;
    [HideInInspector] public SceneType currentScene;


    protected void Awake()
    {
        Instance = this;
        Init();

        DontDestroyOnLoad(this);

        //GameController.Instance.useProfile.IsRemoveAds = true;


#if UNITY_IOS

    if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == 
    ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
    {

        ATTrackingStatusBinding.RequestAuthorizationTracking();

    }

#endif

    }

    private void Start()
    {
        musicManager.PlayBGMusic();
     
    }

    public void Init()
    {

        UseProfile.NumberOfAdsInPlay = 0;
        //Application.targetFrameRate = 60;
        //useProfile.CurrentLevelPlay = UseProfile.CurrentLevel;
        admobAds.Init();
        musicManager.Init();
        iapController.Init();
        MMVibrationManager.SetHapticsActive(useProfile.OnVibration);
        // GameController.Instance.admobAds.ShowBanner();
    }

    public void LoadScene(string sceneName)
    {
        Initiate.Fade(sceneName.ToString(), Color.black, 2f);
    }

  
}
public enum SceneType
{
    StartLoading = 0,
    MainHome = 1,
    GamePlay = 2
}