using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _controller = null;

    [SerializeField] private GameObject _interactUI = null;

    [SerializeField] private EPNJType _typePNJ = EPNJType.SORCIERE;
    [SerializeField] private ERessourceType _typeRessource = ERessourceType.SKULL;
    [SerializeField] private int _amountRessource = 0;

    #region Properties

    public PNJController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public GameObject InteractUI
    {
        get => _interactUI;
        set => _interactUI = value;
    }

    public EPNJType TypePNJ
    {
        get => _typePNJ;
        set => _typePNJ = value;
    }

    public ERessourceType TypeRessource
    {
        get => _typeRessource;
        set => _typeRessource = value;
    }

    public int AmountRessource
    {
        get => _amountRessource; 
        set => _amountRessource = value;
    }

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
        InventoryManager.Instance.AddItem(TypeRessource, AmountRessource);
        Debug.Log("Interact");
    }

    public void FrontUIInteract(bool isDisplay)
    {
        UIManager.Instance.DisplayUI(isDisplay);
    }

    public void BackUIInteract(bool isDisplay)
    {
        UIManager.Instance.DisplayUI(isDisplay);
    }
}
