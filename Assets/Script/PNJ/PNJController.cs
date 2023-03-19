using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private ItemData _itemData = null;
    [SerializeField] private GameObject _VFXSpawnPoint = null;
    [SerializeField] private GameObject _body = null;
    [SerializeField] private float _vFXDuration = 0;
    [SerializeField] private float _vFXEndTimer = 1;
    [SerializeField] private Image _detectionGauge= null;
    

    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        PNJManager.Instance.Controller = this;

        PNJManager.Instance.ItemGet = _itemData;
        PNJDetection.Instance.DetectionGauge = _detectionGauge;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;
        }            
    }

    private void Update()
    {

        if (PNJManager.Instance.IsDead == true)
        {
            _vFXDuration += Time.deltaTime;

            if (_vFXDuration > _vFXEndTimer) 
            { 
                PNJManager.Instance.DestroyAll();
            }
        }
        else
        {
            _vFXDuration = 0;
        }

        if(PNJDetection.Instance.IsCanSeePlayer == true) 
        {
            Detection();        
        }
        else if(PNJDetection.Instance.IsCanSeePlayer == false)
        {
            Undetecte();
        }
    }
    #endregion Mono
    private void Detection()
    {        
        _detectionGauge.fillAmount += PNJDetection.Instance.DetectionFeedBack / 2*Time.deltaTime;           
    }

    private void Undetecte()
    {
        _detectionGauge.fillAmount -= PNJDetection.Instance.DetectionFeedBack / 2 * Time.deltaTime;
    }
}
