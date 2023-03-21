using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PNJDetection : MonoBehaviour
{
    #region Attributs

    [SerializeField] private PNJController _controllerPNJ = null;

    [SerializeField] private float _radius = 0f; 
    [Range(0, 360)]
    [SerializeField] private float _angle = 0f;

    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    [SerializeField] private Image _detectionGauge = null;
    [SerializeField] private float _delayDetection = 2f;
    private float _delayDetectionTimer = 0f;

    #endregion Attributs

    #region Propertie

    public float Radius
    {
        get => _radius;
        set => _radius = value;
    }
    public float Angle
    {
        get => _angle;
        set => _angle = value;
    }
    public float DetectionFeedBack
    {
        get => _delayDetectionTimer;  
        set => _delayDetectionTimer = Mathf.Clamp(value,0,2);
    }
    public Image DetectionGauge
    {
        get => _detectionGauge;
        set => _detectionGauge = value;
    }

    #endregion Properties
    private void Start()
    {
        _delayDetectionTimer = 0;
    }

    private void Update()
    {
        if (CharacterManager.Instance.IsCanBeSee == true)
        {
            FieldOfViewCheck();
        }

        if (_controllerPNJ.IsCanSeePlayer == true && _detectionGauge != null)
        {
            Detection();
        }
        else if (_controllerPNJ.IsCanSeePlayer == false && _detectionGauge != null)
        {
            Undetecte();
        }
    }


    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                {
                    _controllerPNJ.IsCanSeePlayer = true;

                    _delayDetectionTimer += Time.deltaTime;
                                        
                    if (_delayDetectionTimer > _delayDetection)
                    {
                        _delayDetectionTimer = 0;
                        UIManager.Instance.GameOver();
                    }                                        
                }
                else
                {
                    DetectionTimer();
                    
                }
            }
            else
            {
                DetectionTimer();
            }
        }
        else
        {
            DetectionTimer();
        }      
    }

    private void DetectionTimer()
    {
        _delayDetectionTimer = Mathf.Clamp(_delayDetectionTimer -= Time.deltaTime, 0, 2);
        _controllerPNJ.IsCanSeePlayer = false;
    }

    private void Detection()
    {
        DetectionGauge.fillAmount += DetectionFeedBack / 2 * Time.deltaTime;
    }
    private void Undetecte()
    {
        DetectionGauge.fillAmount -= DetectionFeedBack / 2 * Time.deltaTime;
    }
}
