using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJ_VillagerController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private PNJ_VillagerController _PNJVillager = null;
    [SerializeField] private DialogueController _DialogueController = null;
    [SerializeField] private GameObject _body = null;    
    [SerializeField] private ItemData _itemData = null;    
    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private float _VFXEndTimer = 1;
    private float _VFXDuration = 0;
    [SerializeField] private GameObject _characterCompFeedback = null;
    [SerializeField] private RectTransform _dialogueButton;

    [SerializeField] private Animator _animator = null;

    #endregion Attributs

    public RectTransform DialogueButton
    {
        get => _dialogueButton;
        set => _dialogueButton = value;
    }
    public PNJ_VillagerController VillagerController
    {
        get => _PNJVillager;
        set => _PNJVillager = value;
    }
    public DialogueController DialogueController
    {
        get => _DialogueController;
        set => _DialogueController = value;
    }

    #region Mono
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (PNJManager.Instance.IsDead == true)
        {
            _VFXDuration += Time.deltaTime;

            if (_VFXDuration > _VFXEndTimer) 
            { 
                PNJManager.Instance.DestroyAll();
            }
        }
        else
        {
            _VFXDuration = 0;
        }                
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ControllerVillager = _PNJVillager;
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;

            if (VillagerController._characterCompFeedback != null && _dialogueButton.gameObject != null && _dialogueButton != null)
            {
                _characterCompFeedback.SetActive(true);   
                _dialogueButton.gameObject.SetActive(true);
            }
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PNJManager.Instance.ControllerVillager = null;
            PNJManager.Instance.ItemGet = null;
            PNJManager.Instance.VFXSpawner = null;
            PNJManager.Instance.Body = null;

            if (VillagerController._characterCompFeedback != null && _dialogueButton.gameObject != null && _dialogueButton != null)
            {
                _characterCompFeedback.SetActive(false);
                _dialogueButton.gameObject.SetActive(false);
            }
        }
    }


    public void CastAnimation()
    {
        if (UIManager.Instance.IsClawSkillActive == true)
        {
            _animator.SetTrigger("DieByClaw");
        }

        if (UIManager.Instance.IsBiteSkillActive == true)
        {
            _animator.SetTrigger("DieByBite");
        }
    }
    #endregion Mono

}
