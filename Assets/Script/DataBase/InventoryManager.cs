    using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private ItemData _itemGet = null;

    [SerializeField] private int _amountBlood = 5;
    [SerializeField] private int _amountSkull = 0;

    #region Properties

    public ItemData ItemGet
    {
        get => _itemGet;
        set => _itemGet = value;
    }
    public int AmountSkull
    {
        get => _amountSkull;
        set => _amountSkull = value;
    }    
    public int AmountBlood
    {
        get => _amountBlood;
        set => _amountBlood = value;
    }

    #endregion Properties

    public void AddItem()
    {
        if(ERessourceType.SKULL == _itemGet.Type)
        {
            AmountSkull += _itemGet.Amount;
        }

        if (ERessourceType.BLOOD == _itemGet.Type)
        {
            AmountBlood += _itemGet.Amount;

        }
    }
}
