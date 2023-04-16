using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ShopBox : BaseBox
{
    #region instance
    private static ShopBox instance;
    public static ShopBox Setup(bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<ShopBox>(PathPrefabs.SHOP_BOX));
            instance.Init();
        }

        instance.InitState();
        return instance;
    }
    #endregion


    public List<PackInShop> packInShops;
    public Button btnClose;
    public List<GameObject> lsBroad;
    public Button btnBroad_1;
    public Button btnBroad_2;
    public Button btnBroad_3;
    public void Init()
    {
        btnClose.onClick.AddListener(Close);
        btnBroad_1.onClick.AddListener(delegate { ShowBroad(1); });
        btnBroad_2.onClick.AddListener(delegate { ShowBroad(2); });
        btnBroad_3.onClick.AddListener(delegate { ShowBroad(3); });
        foreach (var item in packInShops)
        {
            item.Init();

        }
    }
    public void InitState()
    {
        
    }
    private void ShowBroad(int id)
    {
        foreach(var item in lsBroad)
        {
            item.gameObject.SetActive(false);
        }
        if(id == 1)
        {
            lsBroad[0].SetActive(true); ;
        }
        if (id == 2)
        {
            lsBroad[1].SetActive(true); ;
        }
        if (id == 3)
        {
            lsBroad[2].SetActive(true); ;
        }
    }
}
