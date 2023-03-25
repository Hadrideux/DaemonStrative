using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWitchView : MonoBehaviour
{
    [SerializeField] private GameObject _proximityCamReversed = null;
    [SerializeField] private GameObject _self = null;
    [SerializeField] private GameObject _proximityTrigger = null;
    [SerializeField] private GameObject _dialogueDisable = null;
    [SerializeField] private GameObject _portalEnable = null;
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
        _proximityCamReversed.gameObject.SetActive(true);        
    }
    
    public void OnclickSwitch()
    {
        _proximityTrigger.gameObject.SetActive(false);
        _self.gameObject.SetActive(true);
        _dialogueDisable.gameObject.SetActive(false);
        _portalEnable.gameObject.SetActive(true);
    }
}
