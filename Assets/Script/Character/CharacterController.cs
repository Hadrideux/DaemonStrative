using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    #endregion Attributs

    void Start()
    {
        Debug.Log("Hello");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
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
            Debug.Log(hitInfo);
            _agent.SetDestination(hitInfo.point);
        }
    }

    #endregion Methode
}
