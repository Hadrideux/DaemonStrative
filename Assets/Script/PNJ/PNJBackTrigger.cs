using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJBackTrigger : MonoBehaviour
{
    [SerializeField] private bool _isBack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PNJManager.Instance.BackUIInteract(true);
            CharacterManager.Instance.IsHostile = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                PNJManager.Instance.Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.BackUIInteract(false);
        CharacterManager.Instance.IsHostile = false;
    }
}
