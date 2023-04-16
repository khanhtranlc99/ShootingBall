using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "Datas/GiftDatabase", fileName = "GiftDatabase.asset")]
public class GiftDatabase : SerializedScriptableObject
{
    public Dictionary<GiftType, Gift> giftList;

    public bool GetGift(GiftType giftType, out Gift gift)
    {
        return giftList.TryGetValue(giftType, out gift);
    }

    public Sprite GetIconItem(GiftType giftType)
    {
        Gift gift = null;
        //if (IsCharacter(giftType))
        //{
        //    var Char = GameController.Instance.dataContain.dataSkins.GetSkinInfo(giftType);
        //    if (Char != null)
        //        return Char.iconSkin;
        //}
        bool isGetGift = GetGift(giftType, out gift);
        return isGetGift ? gift.getGiftSprite : null;
    }
    public GameObject GetAnimItem(GiftType giftType)
    {
        Gift gift = null;
        bool isGetGift = GetGift(giftType, out gift);
        return isGetGift ? gift.getGiftAnim : null;
    }

    public void Claim(GiftType giftType, int amount, Reason reason = Reason.none)
    {

        switch (giftType)
        {
            case GiftType.Coin:
                 UseProfile.Coin += amount;
                break;
            case GiftType.Heart:
                UseProfile.Heart += amount;
                break;
            case GiftType.RemoveAds:
                GameController.Instance.useProfile.IsRemoveAds = true;
                //GameController.Instance.admobAds.DestroyBanner();
                break;
            case GiftType.ThunderBooster:
                UseProfile.ThunderBooster += amount;

                break;
            case GiftType.AddBallBooster:
                UseProfile.AddBallsBooster += amount;

                break;


        }
    }

    public static bool IsCharacter(GiftType giftType)
    {
        //switch (giftType)
        //{
        //    case GiftType.RandomSkin:
        //        return true;
        //}
        return false;
    }
}

public class Gift
{
    [SerializeField] private Sprite giftSprite;
    [SerializeField] private GameObject giftAnim;
    public virtual Sprite getGiftSprite => giftSprite;
    public virtual GameObject getGiftAnim => giftAnim;

}

public enum GiftType
{
    None = 0,
    RemoveAds = 1,
    Coin = 2,
    Heart = 3,
    ThunderBooster = 4, 
    AddBallBooster = 5,
    Ball_1 = 6,
    Ball_2 = 7,
    Ball_3 = 8,
    Ball_4 = 9,
    Ball_5 = 10,
    Ball_6 = 11,
    Ball_7 = 12,
    Ball_8 = 13,
}

public enum Reason
{
    none = 0,
    play_with_item = 1,
    watch_video_claim_item_main_home = 2,
    daily_login = 3,
    lucky_spin = 4,
    unlock_skin_in_special_gift = 5,
    reward_accumulate = 6,
}

[Serializable]
public class RewardRandom
{
    public int id;
    public GiftType typeItem;
    public int amount;
    public int weight;

    public RewardRandom()
    {
    }
    public RewardRandom(GiftType item, int amount, int weight = 0)
    {
        this.typeItem = item;
        this.amount = amount;
        this.weight = weight;
    }

    public GiftRewardShow GetReward()
    {
        GiftRewardShow rew = new GiftRewardShow();
        rew.type = typeItem;
        rew.amount = amount;

        return rew;
    }
}
