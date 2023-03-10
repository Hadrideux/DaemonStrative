using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs
    [SerializeField] private bool _isBack = false;

    [SerializeField] private ItemData _itemData = null;
    [SerializeField] private ERessourceType _typeRessource = ERessourceType.SKULL;
    [SerializeField] private int _amountRessource = 0;

    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        PNJManager.Instance.Controller = this;

        PNJManager.Instance.TypeRessource = _typeRessource;
        PNJManager.Instance.AmountRessource = _amountRessource;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.UInteract(true);
            CharacterManager.Instance.IsHostile = true;
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.UInteract(false);
        CharacterManager.Instance.IsHostile = false;
    }

    #endregion Mono
}
