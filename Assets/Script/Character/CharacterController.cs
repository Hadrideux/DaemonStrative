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
        if (Input.GetMouseButtonDown(1))
        {
           CharacterManager.Instance.Moving(_camera, _agent);
        }
    }

    #region Methode


    private void Action()
    {
        //Action exécuté par le joueur
    }


    
    #endregion Methode
}
