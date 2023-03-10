using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs
    [SerializeField] private GameObject _interactUI = null;

    [SerializeField] private EPNJType _typePNJ = EPNJType.SORCIERE;
    [SerializeField] private ERessourceType _typeRessource = ERessourceType.SKULL;
    [SerializeField] private int _amountRessource = 0;

    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        PNJManager.Instance.Controller = this;
        PNJManager.Instance.InteractUI = _interactUI;

        PNJManager.Instance.TypePNJ = _typePNJ;
        PNJManager.Instance.TypeRessource = _typeRessource;
        PNJManager.Instance.AmountRessource = _amountRessource;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion Mono
}
