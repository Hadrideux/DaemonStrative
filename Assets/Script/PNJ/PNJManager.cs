using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controller = null;
    //[SerializeField] private GameObject _interactUI = null;

    [SerializeField] private bool _isCanSeePlayer = false;
    //[SerializeField] private Vector3 _lookAt = Vector3.zero;

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
   
    /*
    public Vector3 LookAt
    {
        get => _lookAt; 
        set => _lookAt = value;
    }
    */

    #endregion Properties

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion MONO

    public void Interact()
    {
        
    }

    public void UInteract(bool isDisplay)
    {
        UIManager.Instance.DisplayUI(isDisplay);
    }

    /*
    public void LookAtPlayer(bool isSee)
    {
        if (isSee)
        {
            LookAt = transform.LookAt(_target.position);
        }        
    }
    */

    public void KillVillager()
    {
        InventoryManager.Instance.AddItem(ItemGet);
    }
}
