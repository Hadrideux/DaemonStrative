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
            PNJManager.Instance.UInteract(true);
            CharacterManager.Instance.IsHostile = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.UInteract(false);
        CharacterManager.Instance.IsHostile = false;
    }
}
