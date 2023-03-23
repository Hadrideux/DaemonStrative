using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{

    [SerializeField] private ItemData _itemData = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.ItemGet = _itemData;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InventoryManager.Instance.ItemGet = null;
        Destroy(gameObject);
    }
}
