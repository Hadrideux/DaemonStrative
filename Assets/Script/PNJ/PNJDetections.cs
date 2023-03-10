using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJDetections : Singleton<PNJDetections>
{
    #region Attributs

    [SerializeField] private float _radius = 0f; [Range(0, 360)]
    [SerializeField] private float _angle = 0f;

    [SerializeField] private CharacterConrtoller _playerRef = null;

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

    public CharacterConrtoller PlayerRef
    {
        get => _playerRef;
        set => _playerRef = value;
    }

    #endregion Properties

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    /// <summary>
    /// je cormprend pas ALEEED
    /// </summary>
    /// <returns></returns>
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
                    IsCanSeePlayer = true;
                    Actualisation();
                }
                else
                {
                    IsCanSeePlayer = false;
                }
            }
            else
            {
                IsCanSeePlayer = false;
                Actualisation();
            }
        }
        else if (IsCanSeePlayer)
        {
            IsCanSeePlayer = false;
        }        
    }

    private void Actualisation()
    {
        PNJManager.Instance.UInteract(IsCanSeePlayer);
        //PNJManager.Instance.LookAtPlayer(IsCanSeePlayer);
    }


}
