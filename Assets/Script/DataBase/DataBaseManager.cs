using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : Singleton<DataBaseManager>
{
    [SerializeField] private ItemData[] _items = null;

    private Dictionary<string, ItemData> _dataBase = null;

    protected override void Start()
    {
        base.Start();

        _dataBase = new Dictionary<string, ItemData>();

        for (int i = 0; i <= _items.Length - 1; i++)
        {
            ItemData item = _items[i];
            _dataBase.Add(item.Name, item);
        }

    }
    /*public ItemData GetItemAmount()
    {
        //ItemData amountData = _items[].Amount;
        //ajout de la quantité dans la variable concerné pour l'item
    }*/
}
