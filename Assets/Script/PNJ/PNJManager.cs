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
        get { return _typePNJ; }
        set { _typePNJ = value; }
    }

    public ERessourceType TypeRessource
    {
        get { return _typeRessource; }
        set { _typeRessource = value; }
    }

    public int AmountRessource
    {
        get { return _amountRessource; }
        set { _amountRessource = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        //DialogueManager.Instance.PNJDialogue();
        UIManager.Instance.DisplayUI();
        InventoryManager.Instance.AddItem(TypeRessource, AmountRessource);
    }

    public void UIInteract(bool value)
    {
        _interactUI.SetActive(value);   //Display de l'ui d'interaction
    }
}
