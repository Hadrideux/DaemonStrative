using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Skull : MonoBehaviour
{
    [SerializeField] private GameObject _skullRef = null;
    [SerializeField] private GameObject _focusCamRef = null;
    [SerializeField] private GameObject _UIActivation = null;
    [SerializeField] private GameObject _playerCam = null;
    
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
        _focusCamRef.SetActive(false);
        _UIActivation.gameObject.SetActive(true);        
        _playerCam.SetActive(true);
        Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        _UIActivation.gameObject.SetActive(false);
        _focusCamRef.SetActive(true);
        _playerCam.SetActive(false);
        Debug.Log("Exit");
    }

    public void StealSkull() 
    {
        InventoryManager.Instance.AmountSkull += 1;
        Destroy(_skullRef);
        _UIActivation.gameObject.SetActive(false);
        _focusCamRef.SetActive(false);        
    }
}
