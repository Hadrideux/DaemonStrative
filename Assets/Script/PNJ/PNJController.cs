using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    [SerializeField] private GameObject _interactUI = null;

    #region Mono

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    #endregion Mono

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
        if (!other.CompareTag("Player"))
        {
            UIInteract(false);
        }
    }

    public void UIInteract(bool value)
    {
        _interactUI.SetActive(value);
        //Display de l'ui d'interaction
    }
}
