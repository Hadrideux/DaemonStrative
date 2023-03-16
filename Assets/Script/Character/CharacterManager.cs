using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterConrtoller _controller = null;
    [SerializeField] private GameObject _collider = null;
    [SerializeField] private GameObject _body = null;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    [SerializeField] private bool _isHostile = false;
    [SerializeField] private bool _isCanBeSee = true;

    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private GameObject _VFXType = null;
    [SerializeField] private GameObject _VFXOmbremarche = null;


    #region Properties

    public bool IsCanBeSee
    {
        get => _isCanBeSee; 
        set => _isCanBeSee = value;
    }
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

    public GameObject Body
    {
        get => _body;
        set => _body = value;
    }

    public GameObject VFXSpawner
    {
        get => _VFXSpawnPoint;
        set => _VFXSpawnPoint = value;
    }

    public GameObject VFXSkills
    {
        get => _VFXType;
        set => _VFXType = value;
    }

    public GameObject VFXOmbremarche
    {
        get => _VFXOmbremarche;
        set => _VFXOmbremarche = value;
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
                Agent.isStopped = false;
                Agent.SetDestination(hitInfo.point);
            }
        }
        
    }

    #region Player Action
    /// <summary>
    /// Fonction des action du joueur durant les différente phase de jeux
    /// </summary>

    public void Morsure()
    {
        if (IsHostile)
        {
            BloodAndFlesh();
            
            PNJManager.Instance.KillVillager();
            Debug.Log("Morsure");
            
        }
    }

    public void BloodAndFlesh()
    {
        Debug.Log("Blood");
        
        Instantiate(_VFXType, _VFXSpawnPoint.transform);
    }


    public void Griffe()
    {

        if (IsHostile)
        {
            BloodAndFlesh();
                      
            Destroy(_body);
            PNJManager.Instance.KillVillager();
            Debug.Log("Griffure");
        }       
    }

    public void DestroyAll()
    {
        Destroy(_collider);
        PNJManager.Instance.isDead = false;
    }
    public void Shadowalk()
    {
        UIManager.Instance.OmbreMarcheTime();
        Debug.Log("tchachachacha");
        IsCanBeSee = false;
        UIManager.Instance.IsCast = true;
    }

    #endregion Player Action

    #endregion Methode
}