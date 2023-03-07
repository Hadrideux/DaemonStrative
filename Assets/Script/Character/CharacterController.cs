using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public void Moving()
    { 
        Ray movePosition = CharacterManager.MousePosition;
        
        if (Physics.Raycast(movePosition, out var hitInfo))
        {
            Debug.Log(hitInfo);
            _agent.SetDestination(hitInfo.point);
        }       
    }
}
