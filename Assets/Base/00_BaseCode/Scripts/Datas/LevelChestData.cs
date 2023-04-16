using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Datas/LevelChestData", fileName = "LevelChestData.asset")]

public class LevelChestData : ScriptableObject
{
    public List<levelChest> lsLevelChest;
}
[System.Serializable]
public class levelChest
{
    public int level;
    public GiftType giftType;
    public int amount;
}
