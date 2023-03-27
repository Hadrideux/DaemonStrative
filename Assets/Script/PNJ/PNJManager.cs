using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controllerPNJ = null;
    [SerializeField] private PNJ_VillagerController _villagerPNJ = null;

    [SerializeField] private DialogueController _Dialogue = null;
        
    [SerializeField] private GameObject _body = null;
    [SerializeField] private GameObject _VFXSpawnPoint = null;    
       
    [SerializeField] private ItemData _itemData = null;
    [SerializeField] private bool _isDying = false;
    //[SerializeField] private bool _isSeePlayer = false;

    #region Properties
    
    public PNJController ControllerPNJ
    {
        get => _controllerPNJ;
        set => _controllerPNJ = value;
    }
    public PNJ_VillagerController ControllerVillager
    {
        get => _villagerPNJ;
        set => _villagerPNJ = value;
    }
    public DialogueController Dialogue
    {
        get => _Dialogue;
        set => _Dialogue = value;
    }
    public GameObject Body
    {
        get => _body;
        set => _body = value;
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

    public void KillVillager(bool isKill)
    {
        InventoryManager.Instance.ItemGet = _itemData;
        InventoryManager.Instance.AddItem();

        if (ControllerPNJ != null )
        {
            ControllerPNJ.CastAnimation();
        }

        if (ControllerVillager != null)
        {
            ControllerVillager.CastAnimation();
        }

        if (isKill)
        {
            IsDead = true;
            Destroy(Body);
        }
        
    }
    public void DestroyAll()
    { 
        Destroy(CharacterManager.Instance.Collider);
        IsDead = false;
    }

    

}
