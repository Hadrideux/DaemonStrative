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

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.UInteract(true);
            CharacterManager.Instance.IsHostile = true;
        }            
    }
    private void OnTriggerExit(Collider other)
    {
        //PNJManager.Instance.UInteract(false);
        CharacterManager.Instance.IsHostile = false;
    }

    #endregion Mono
}
