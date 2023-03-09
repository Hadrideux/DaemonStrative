using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJBackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PNJController.Instance.UIInteract(true);

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
            PNJController.Instance.UIInteract(false);
        }
    }
}
