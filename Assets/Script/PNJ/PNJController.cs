using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private ItemData _itemData = null;
    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private GameObject _body = null;
    [SerializeField] private float _vFXDuration = 0;
    [SerializeField] private float _vFXEndTimer = 1;
    

    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        PNJManager.Instance.Controller = this;

        PNJManager.Instance.ItemGet = _itemData;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            CharacterManager.Instance.IsHostile = true;
            CharacterManager.Instance.VFXSpawner = _VFXSpawnPoint;
            CharacterManager.Instance.Body = _body;
        }            
    }
    private void OnTriggerExit(Collider other)
    {
        CharacterManager.Instance.IsHostile = false;
    }

    private void Update()
    {

        if (PNJManager.Instance.isDead == true)
        {
            _vFXDuration += Time.deltaTime;

            if (_vFXDuration > _vFXEndTimer) 
            { 
                CharacterManager.Instance.DestroyAll();
            }
        }
        else
        {
            _vFXDuration = 0;
        }
    }
    #endregion Mono
}
