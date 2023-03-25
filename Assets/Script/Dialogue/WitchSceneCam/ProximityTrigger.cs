using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _proximityCam = null;
    [SerializeField] private GameObject _dialogueActivation = null;
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
        _proximityCam.gameObject.SetActive(true);
        _dialogueActivation.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _proximityCam.gameObject.SetActive(false);
        _dialogueActivation.gameObject.SetActive(false);
    }
}
