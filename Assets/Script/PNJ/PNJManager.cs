using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controller = null;
    [SerializeField] private PNJDetection _detection = null;

    [SerializeField] private GameObject _body = null;
    [SerializeField] private GameObject _VFXSpawnPoint = null;    
       
    [SerializeField] private ItemData _itemData = null;
    [SerializeField] private bool _isDying = false;

    #region Properties

    public PNJController Controller
    {
        get => _controller;
        set => _controller = value;
    }
    public GameObject Body
    {
        get => _body;
        set => _body = value;
    }

    public PNJDetection Detection
    {
        get => _detection;
        set => _detection = value;
    }
    public bool IsDead
    {
        get => _isDying;
        set => _isDying = value;
    }

    public ItemData ItemGet
    {
        get => _itemData;
        set => _itemData = value;
    }
    
    public GameObject VFXSpawner
    {
        get => _VFXSpawnPoint;
        set => _VFXSpawnPoint = value;
    }
        
    #endregion Properties

    public void KillVillager()
    {
        InventoryManager.Instance.AddItem(ItemGet);
        Destroy(Body);
    }
    public void DestroyAll()
    {
        Destroy(CharacterManager.Instance.Collider);
        IsDead = false;
    }

}
