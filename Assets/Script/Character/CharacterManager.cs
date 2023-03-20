using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterConrtoller _controller = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private NavMeshAgent _agent = null;

    [SerializeField] private GameObject _collider = null;
    [SerializeField] private bool _isCanBeSee = true;

    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private GameObject _VFXSkills = null;
    [SerializeField] private GameObject _VFXOmbremarche = null;

    [SerializeField] private GameObject _VFXHitPointNavigation = null;

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
    public GameObject Collider
    {
        get => _collider;
        set => _collider = value;
    }
    public GameObject VFXSkills
    {
        get => _VFXSkills;
        set => _VFXSkills = value;
    }
    public GameObject VFXOmbremarche
    {
        get => _VFXOmbremarche;
        set => _VFXOmbremarche = value;
    }
    public GameObject VFXHitPointNavigation
    {
        get => _VFXHitPointNavigation;
        set => _VFXHitPointNavigation = value;
    }

    #endregion properties

    private void Update()
    {
        EndMovement();
    }

    #region Methode

    public void Moving()
    {
        if (!DialogueManager.Instance.IsDialogueActive == true && Agent.isStopped == false)
        {
            Ray movePosition = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                Agent.isStopped = false;
                Agent.SetDestination(hitInfo.point);

                VFXHitPointNavigation.gameObject.SetActive(true);
                VFXHitPointNavigation.transform.position = new Vector3(hitInfo.point.x, 0.5f, hitInfo.point.z);
            }
        }       
    }

    public void EndMovement()
    {
        if (_agent.remainingDistance < 0.05f)
        {
            VFXHitPointNavigation.gameObject.SetActive(false);
        }
    }

    #region Player Action
    /// <summary>
    /// Fonction des action du joueur durant les différente phase de jeux
    /// </summary>

    public void Morsure()
    {
        BloodAndFlesh();

        PNJManager.Instance.KillVillager();
        PNJManager.Instance.IsDead = true;

        UIManager.Instance.AlphaMorsure();
    }
    public void Griffe()
    {
        BloodAndFlesh();

        PNJManager.Instance.IsDead = true;
        PNJManager.Instance.KillVillager();

        UIManager.Instance.AlphaGriffure();
    }
    public void Shadowalk()
    {
        UIManager.Instance.IsCast = true;
        UIManager.Instance.OmbreMarcheTime();
        IsCanBeSee = false;
    }

    #endregion Player Action

    public void BloodAndFlesh()
    {
        Instantiate(VFXSkills, PNJManager.Instance.VFXSpawner.transform);
    }

    #endregion Methode
}