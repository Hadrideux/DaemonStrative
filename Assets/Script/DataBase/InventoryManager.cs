using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private ItemGetteur _itemGet = null;
    // Start is called before the first frame update
    void Start()
    {
        //ItemData itemAmount = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public ItemData GetItemAmount()
    {
        ItemData amountData = _itemGet.ItemDataGet.Amount;
        Debug.Log(amountData);
        //ajout de la quantité dans la variable concerné pour l'item
    }
    */
}
