using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetteur : MonoBehaviour
{
    [SerializeField] private ItemData _items = null;
    //[SerializeField] private bool _pickUp = false;


    public ItemData ItemDataGet
    {
        get => _items;
        set => _items = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Affichage de l'UI d'interaction

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //InventoryManager.Instance.GetItemAmount(ItemDataGet);
            Destroy(gameObject);
        }
    }
}