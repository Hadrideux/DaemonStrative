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

    public RectTransform DialogueButton
    {
        get => _dialogueButton;
        set => _dialogueButton = value;
    }
    #endregion Attributs
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;

            if (VillagerController._characterCompFeedback != null)
            {
                VillagerController._characterCompFeedback.SetActive(true);
                VillagerController._dialogueButton.gameObject.SetActive(true);
            }
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        PNJManager.Instance.ItemGet = null;
        PNJManager.Instance.VFXSpawner = null;
        PNJManager.Instance.Body = null;

        if (VillagerController._characterCompFeedback != null)
        {
            VillagerController._characterCompFeedback.SetActive(false);
            VillagerController._dialogueButton.gameObject.SetActive(false);
        }

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
    #endregion Mono
       
}
