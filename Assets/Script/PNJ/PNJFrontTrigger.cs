using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJFrontTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            PNJManager.Instance.FrontUIInteract(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PNJManager.Instance.Interact();
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.FrontUIInteract(false);
    }
}
