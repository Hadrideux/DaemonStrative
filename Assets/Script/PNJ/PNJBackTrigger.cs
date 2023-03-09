using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJBackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           CharacterManager.Instance.IsHostile = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
