using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int _amountBlood = 0;
    [SerializeField] private int _amountSkull = 0;

    #region Properties

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

    public void AddItem(ItemData itemGet)
    {
        if(ERessourceType.SKULL == itemGet.Type)
        {
            AmountSkull += itemGet.Amount;
            Debug.Log(itemGet.Name + " : " + AmountSkull);
        }

        if (ERessourceType.BLOOD == itemGet.Type)
        {
            AmountBlood += itemGet.Amount;
            Debug.Log(itemGet.Name + " : " + AmountBlood);
        }
    }
}
