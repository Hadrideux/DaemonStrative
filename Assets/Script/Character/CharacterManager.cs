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
    [SerializeField] private List<PNJDetection> _detectedBy = new List<PNJDetection>();

    [SerializeField] private GameObject _skillsVFX = null;

    [SerializeField] private GameObject _VFXOmbremarche = null;

    #region Properties

    public bool IsCanBeSee
    {
        get => _isCanBeSee;
        set => _isCanBeSee = value;
    }   
    public List<PNJDetection> DetectedBy
    {
        get => _detectedBy;
        set => _detectedBy = value;
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
    public GameObject SkillsVFX
    {
        get => _skillsVFX;
        set => _skillsVFX = value;
    }
    public GameObject VFXOmbremarche
    {
        get => _VFXOmbremarche;
        set => _VFXOmbremarche = value;
    }

    #endregion properties

    private void Update()
    {
        CastVignetDetection();
    }

    #region Methode

    #region Player Action

    public void BiteAction()
    {
        CastVFXOnCollider();

        PNJManager.Instance.KillVillager(true);

        UIManager.Instance.ToggleBiteSkillButton(true);
        UIManager.Instance.IsBiteSkillActive = true;
    }   
    public void ClawAction()
    {
        CastVFXOnCollider();

        PNJManager.Instance.KillVillager(true);

        UIManager.Instance.ToggleClawSkillButton(true);
        UIManager.Instance.IsClawSkillActive = true;        
    }
    public void ShadoStepAction()
    {
        UIManager.Instance.ToggleShadowStepButton(true);
        UIManager.Instance.IsShadowStepSkillActive = true;
        
        IsCanBeSee = false;

        InventoryManager.Instance.AmountBlood -= 15;
    }

    #endregion Player Action

    public void CastVFXOnCollider()
    {
        if (Collider != null)
        {
            Instantiate(SkillsVFX, PNJManager.Instance.VFXSpawner.transform);
        }
    }

    private void CastVignetDetection()
    {
        if(DetectedBy.Count > 0)
        {
            // Alerte
            _controller.AnimationDetection.gameObject.SetActive(true);
            _controller.AnimationDetection.enabled = true;
            _controller.AnimationDetection.Play("Fade_Vignettage_Detection");
        }
        else if (DetectedBy.Count == 0)
        {
            // Pas d'alerte
            _controller.AnimationDetection.gameObject.SetActive(false);
            _controller.AnimationDetection.enabled = false;
        }
    }

    #endregion Methode;
}