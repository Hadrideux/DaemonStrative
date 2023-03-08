using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    [SerializeField] private GameObject _interactUI = null;
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
        if(other.tag == "Player" )
        {
            //UIManager.Instance.UIInteract();
            UIInteract();

            if (Input.GetKeyDown(KeyCode.E))
            {
                //PNJManager.Instance.TargetPnj = ;
                PNJManager.Instance.Interact();
            }
        }
        
    }

    public void UIInteract()
    {
        _interactUI.SetActive(true);
    }
}
