using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterConrtoller _controller = null;
    [SerializeField] private GameObject _collider = null;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;


    [SerializeField] private bool _isHostile = false;

    #region Properties

    public CharacterConrtoller Controller
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

    public GameObject Collider
    {
        get => _collider;
        set => _collider = value;
    }

    #endregion properties

    #region Methode

    public void Moving()
    {
        if (DialogueManager.Instance.IsDialogueActive == true)
        {
            return;
        }
        else
        {
            Ray movePosition = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                Agent.SetDestination(hitInfo.point);
            }
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
            PNJManager.Instance.KillVillager();
            UIManager.Instance.MorsureTime();
            Destroy(Collider);
            
            IsHostile = false;
            
            Debug.Log("Morsure");
        }
    }

    public void Griffe()
    {
        if (IsHostile)
        {
            PNJManager.Instance.KillVillager();
            UIManager.Instance.GriffeTime();
            
            Destroy(Collider);
            
            IsHostile = false;
            
            Debug.Log("Griffure");
        }       
    }

    public void Shadowalk()
    {
        UIManager.Instance.OmbreMarcheTime();
        Debug.Log("tchachachacha");
    }

    #endregion Player Action

    #endregion Methode
}