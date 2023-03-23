using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DialogueLookAtCam : MonoBehaviour
{
    [SerializeField] private Camera _cameraTarget = null;

   
    void Update()
    {
        if (_cameraTarget == null)
        {
            _cameraTarget = CharacterManager.Instance.Camera;
        }

        transform.LookAt(_cameraTarget.transform.position);
    }
}
