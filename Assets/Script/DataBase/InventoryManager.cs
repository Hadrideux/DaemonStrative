using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int _amountBlood = 0;
    [SerializeField] private int _amountSkull = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ERessourceType typeRessource, int amountRessource)
    {
        if(ERessourceType.SKULL == typeRessource)
        {
            _amountSkull += amountRessource ;
        }

        if (ERessourceType.BLOOD == typeRessource)
        {
            _amountBlood += amountRessource;
        }
    }
}
