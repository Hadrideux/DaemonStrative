using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    #endregion Attributs

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Moving();
        }
    }

    #region Methode
    
    private void Moving()
    {
        Ray movePosition = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(movePosition, out var hitInfo))
        {
            _agent.SetDestination(hitInfo.point);
        }
    }

    private void Action()
    {
        //Action exécuté par le joueur
    }


    
    #endregion Methode
}
