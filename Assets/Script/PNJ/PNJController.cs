using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private PNJController _pNJController = null;
    [SerializeField] private PNJDetection _pNJDetection = null;
    [SerializeField] private PNJMovement _pNJMovement = null;
    [SerializeField] private GameObject _body = null;

    [SerializeField] private ItemData _itemData = null;

    [SerializeField] private GameObject _VFXSpawnPoint = null;
    private float _VFXDuration = 0;
    [SerializeField] private float _VFXEndTimer = 1;

    [SerializeField] private Image _detectionGauge = null;

    #endregion Attributs

    public PNJController ControllerPNJ
    {
        get => _pNJController;
        set => _pNJController = value;
    }
    public PNJDetection DetectionPNJ
    {
        get => _pNJDetection;
        set => _pNJDetection = value;
    }

    public PNJMovement MovementPNJ
    {
        get => _pNJMovement;
        set => _pNJMovement = value;
    }
   
    public Image DetectionGauge
    {
        get => _detectionGauge;
        set => _detectionGauge = value;
    }

    #region Mono

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;
        }            
    }

    private void OnTriggerExit(Collider other) 
    {
        PNJManager.Instance.ItemGet = null;
        PNJManager.Instance.VFXSpawner = null;
        PNJManager.Instance.Body = null;
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

        if(DetectionPNJ.IsCanSeePlayer == true && _detectionGauge != null) 
        {
            Detection();        
        }
        else if(DetectionPNJ.IsCanSeePlayer == false && _detectionGauge != null)
        {
            Undetecte();
        }
    }
    #endregion Mono

    private void Detection()
    {

        DetectionGauge.fillAmount += DetectionPNJ.DetectionFeedBack / 2*Time.deltaTime;           
    }

    private void Undetecte()
    {
        DetectionGauge.fillAmount -= DetectionPNJ.DetectionFeedBack / 2 * Time.deltaTime;
    }
}
