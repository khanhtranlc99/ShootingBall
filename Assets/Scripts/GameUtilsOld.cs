using System;
using UnityEngine;

public class GameUtilsOld
{
    public static int GetUnlockLevel()
    {       
        if (!PlayerPrefs.HasKey(DataString.levelUnlock))
        {
            PlayerPrefs.SetInt(DataString.levelUnlock, 1);
            
        }

        return PlayerPrefs.GetInt(DataString.levelUnlock);
    }

    public static bool Sound
    {
        get { return CPlayerPrefs.GetBool(DataString.KeySound, true); }
        set { CPlayerPrefs.SetBool(DataString.KeySound, value); }
    }
}
