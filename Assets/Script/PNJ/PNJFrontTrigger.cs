using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJFrontTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PNJManager.Instance.UIInteract(true);

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PNJManager.Instance.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.UIInteract(false);
    }
}
