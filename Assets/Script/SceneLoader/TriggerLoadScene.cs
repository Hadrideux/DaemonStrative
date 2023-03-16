using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadScene : MonoBehaviour
{
    [SerializeField] private bool _isGoWitchScene = false;
    [SerializeField] private bool _isGoGameScene = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isGoWitchScene)
            {
                Debug.Log("Load Witch");
                GameLoaderManager.Instance.LoadWitchScene();
            }
            if (_isGoGameScene)
            {
                Debug.Log("Load Witch");
                GameLoaderManager.Instance.LoadGameScene();
            }
        }
    }
}
