using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterManager : MonoBehaviour
{

    /*
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    #region Properties
    
    public Ray MousePosition
    {
        get
        {
            return _agent.MousePosition;
        }
    }
    
    #endregion Properties
    */

    // Update is called once per frame
    void Update()
    {
        ActionInput();
    }

    private void ActionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Interact with PNJ
        }
        if (Input.GetMouseButton(1))
        {
            /*
            MousePosition = _camera.ScreenPointToRay(Input.mousePosition);
            CharacterController.Moving();
            Moving Character to destination
            */
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //rotation de la caméra
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //rotation de la caméra
        }
    }
}
