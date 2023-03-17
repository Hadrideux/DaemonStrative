using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controller = null;

    [SerializeField] private ItemData _itemData = null;

    [SerializeField] private bool _isDying = false;
    [SerializeField] private float _VFXDuration = 0f;
    

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

    public bool isDead
    {
        get => _isDying;
        set => _isDying = value;
    }

    public float VFXTimer
    {
        get => _VFXDuration;
        set => _VFXDuration = value;
    }
        
    #endregion Properties

    public void KillVillager()
    {
        InventoryManager.Instance.AddItem(ItemGet);
    }
        
}
