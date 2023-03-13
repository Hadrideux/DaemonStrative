using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controller = null;

    [SerializeField] private ItemData _itemData = null;

    #region Properties

    public PNJController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public ItemData ItemGet
    {
        get => _itemData;
        set => _itemData = value;
    }

    #endregion Properties

    public void KillVillager()
    {
        InventoryManager.Instance.AddItem(ItemGet);
    }
}
