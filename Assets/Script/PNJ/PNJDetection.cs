using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PNJDetection : MonoBehaviour
{
    #region Attributs

    [SerializeField] private float _radius = 0f; [Range(0, 360)]
    [SerializeField] private float _angle = 0f;

    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    [SerializeField] private bool _isCanSeePlayer = false;
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
    public bool IsCanSeePlayer
    {
        get => _isCanSeePlayer;
        set => _isCanSeePlayer = value;
    }
    public float DetectionFeedBack
    {
        get => _delayDetectionTimer;  
        set => _delayDetectionTimer = Mathf.Clamp(value,0,2);
    }

    #endregion Properties

    private void Update()
    {
        if (CharacterManager.Instance.IsCanBeSee)
        {
            FieldOfViewCheck();
        }
    }   

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                {
                    IsCanSeePlayer = true;

                    _delayDetectionTimer += Time.deltaTime;
                                        
                    if (_delayDetectionTimer > _delayDetection)
                    {
                        UIManager.Instance.GameOver();
                    }                                        
                }
                else
                {
                    _delayDetectionTimer = Mathf.Clamp(_delayDetectionTimer -= Time.deltaTime,0,2);
                    IsCanSeePlayer = false;
                }
            }
            else
            {
                _delayDetectionTimer = Mathf.Clamp(_delayDetectionTimer -= Time.deltaTime, 0, 2);
                IsCanSeePlayer = false;
            }
        }
        else //if (IsCanSeePlayer)
        {
            _delayDetectionTimer = Mathf.Clamp(_delayDetectionTimer -= Time.deltaTime, 0, 2);
            IsCanSeePlayer = false;
        }      
    }    
}
