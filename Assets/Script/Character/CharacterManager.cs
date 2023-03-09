using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterController _controller = null;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;


    [SerializeField] private bool _isHostile = false;

    #region Properties

    public CharacterController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public NavMeshAgent Agent
    {
        get => _agent; 
        set => _agent = value;
    }

    public Camera Camera
    {
        get => _camera; 
        set => _camera = value;
    }

    public bool IsHostile
    {
        get => _isHostile;
        set => _isHostile = value;
    }

    #endregion properties

    void Update()
    {
        if (IsHostile)
        {
        }
    }
    #region Methode
    public void Moving(/*Camera camera, NavMeshAgent agent*/)
    {
        Ray movePosition = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(movePosition, out var hitInfo))
        {
            Agent.SetDestination(hitInfo.point);
        }
    }

    #region Player Action
    /// <summary>
    /// Fonction des action du joueur durant les différente phase de jeux
    /// </summary>
    /// 
    public void Morsure()
    {
        if (IsHostile)
        {
            Debug.Log("Morsure");
        }
    }

    public void Griffe()
    {
        if (IsHostile)
        {
            Debug.Log("Griffure");
        }       
    }
    public void Shadowalk()
    {
        Debug.Log("tchachachacha");
    }

    #endregion Player Action

    #endregion Methode
}