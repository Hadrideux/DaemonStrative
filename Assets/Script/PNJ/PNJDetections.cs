using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJDetections : Singleton<PNJDetections>
{
    #region Attributs

    [SerializeField] private float _radius = 0f; [Range(0, 360)]
    [SerializeField] private float _angle = 0f;

    [SerializeField] private GameObject _playerRef = null;

    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    [SerializeField] private bool _isCanSeePlayer = false;

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

    public GameObject PlayerRef
    {
        get => _playerRef;
        set => _playerRef = value;
    }

    #endregion Properties

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
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
                }
                else
                {
                    IsCanSeePlayer = false;
                }
            }
            else
            {
                IsCanSeePlayer = false;
            }
        }
        else //if (IsCanSeePlayer)
        {
            IsCanSeePlayer = false;
        }      
    }
}
