using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    [SerializeField] private GameObject _interactUI = null;

    //[SerializeField] private GameObject _frontTrigger = null;
    //[SerializeField] private GameObject _backTrigger = null;

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
        if(other.tag == "Player")
        {
            Debug.Log(other.tag);
            UIInteract(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //PNJManager.Instance.TargetPnj = ;
                PNJManager.Instance.Interact();
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        UIInteract(false);
    }

    public void UIInteract(bool value)
    {
        _interactUI.SetActive(value);
        //Display de l'ui d'interaction
    }
}
