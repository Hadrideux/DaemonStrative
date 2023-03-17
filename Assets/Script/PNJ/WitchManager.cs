using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : Singleton<WitchManager>
{
    [SerializeField] private WitchController _witchController = null;

    [SerializeField] private bool _isQuestOmbreMarche = false;

    public WitchController WitchController
    {
        get => _witchController;
        set => _witchController = value;
    }

    public bool IsQuestOmbreMarche
    {
        get => _isQuestOmbreMarche;
        set => _isQuestOmbreMarche = value;
    }

    public void QuêteOmbreMarche()
    {
        if (_isQuestOmbreMarche)
        {
            InventoryManager.Instance.AmountSkull = 0;
            InventoryManager.Instance.AmountBlood = 0;
        }
        
    }
}
