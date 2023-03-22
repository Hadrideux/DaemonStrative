using Engine.Utils;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private CharacterConrtoller _controller = null;
    [SerializeField] private Camera _camera = null;
    

    [SerializeField] private NavMeshAgent _agent = null;

    [SerializeField] private GameObject _collider = null;
    [SerializeField] private bool _isCanBeSee = true;

    [SerializeField] private GameObject _skillsVFX = null;
    [SerializeField] private AudioClip _skillsSFX = null;

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
    public AudioClip SkillsSFX
    {
        get => _skillsSFX;
        set => _skillsSFX = value;
    }
    public GameObject VFXOmbremarche
    {
        get => _VFXOmbremarche;
        set => _VFXOmbremarche = value;
    }

    #endregion properties

    #region Methode

    #region Player Action
    /// <summary>
    /// Fonction des action du joueur durant les différente phase de jeux
    /// </summary>
    public void BiteAction()
    {
        BloodAndFlesh();

        PNJManager.Instance.KillVillager(false);

        UIManager.Instance.ToggleBiteSkillButton(true);
        UIManager.Instance.IsBiteSkillActive = true;
    }   
    public void ClawAction()
    {
        BloodAndFlesh();

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

    public void BloodAndFlesh()
    {
        if (_collider != null)
        Instantiate(SkillsVFX, PNJManager.Instance.VFXSpawner.transform);
    }
          
    #endregion Methode;
}