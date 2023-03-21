using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Comp_Feedback : MonoBehaviour
{
    [SerializeField] private Camera _cameraTarget = null;
 
   
    void Update()
    {
        if (_cameraTarget == null)
        {
            _cameraTarget = CharacterManager.Instance.Camera;
        }

        transform.rotation = Quaternion.LookRotation(transform.position - _cameraTarget.transform.position);

        
    }
}
