using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJ_VillagerController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private PNJ_VillagerController _PNJVillager = null;    
    [SerializeField] private GameObject _body = null;    
    [SerializeField] private ItemData _itemData = null;    
    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private float _VFXEndTimer = 1;
    private float _VFXDuration = 0;
    
    #endregion Attributs
    
    public PNJ_VillagerController ControllerPNJ
    {
        get => _PNJVillager;
        set => _PNJVillager = value;
    }

    #region Mono

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;
        }            
    }

    private void Update()
    {

        if (PNJManager.Instance.IsDead == true)
        {
            _VFXDuration += Time.deltaTime;

            if (_VFXDuration > _VFXEndTimer) 
            { 
                PNJManager.Instance.DestroyAll();
            }
        }
        else
        {
            _VFXDuration = 0;
        }
                
    }
    #endregion Mono
       
}