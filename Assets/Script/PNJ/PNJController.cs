using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private ItemData _itemData = null;

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
        }            
    }
    private void OnTriggerExit(Collider other)
    {
        CharacterManager.Instance.IsHostile = false;
    }

    #endregion Mono
}
