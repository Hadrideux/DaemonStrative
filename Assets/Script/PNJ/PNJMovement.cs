using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class PNJMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float _timeToWalk = 0;
    [SerializeField] private float _waitTimer = 0;
    [SerializeField] private float _waitTimerOut = 0;
    [SerializeField] private bool _isWalking = false;
    [SerializeField] private int _activePoint = 0;
    [SerializeField] private float _walkingTimeSpend = 0;
    [SerializeField] private bool _isGuard = false;

    public WayPoint[] _wayPoints;

    [System.Serializable]
    public class WayPoint
    {
        public GameObject target;
    }


    // Start is called before the first frame update
    void Start()
    {
        _activePoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGuard == true)
        {
            if (PNJDetections.Instance.IsCanSeePlayer == false)
            {
                WalkRound();
            }
            else
            {
                UIManager.Instance.GameOver();
            }
        }
        
    }

    private void WalkRound()
    {
        
        WayPoint actualPoint = _wayPoints[_activePoint];
        _walkingTimeSpend += Time.deltaTime;
        _waitTimer += Time.deltaTime;

        if (actualPoint != null && _timeToWalk > _walkingTimeSpend && _isWalking == true) 
        {

            agent.SetDestination(actualPoint.target.transform.position);            
            _waitTimer = 0;
            
        }
        else if (_isWalking = true && _timeToWalk < _walkingTimeSpend && _waitTimerOut > _waitTimer)
        {
            _isWalking= false;            
            
        }
        else if (_isWalking == false && _activePoint < _wayPoints.Length- 1 && _waitTimerOut < _waitTimer)
        {
            _activePoint += 1;
            _walkingTimeSpend = 0;
            _waitTimer = 0;
            _isWalking = true;

            Debug.Log(_activePoint.ToString());
        }        
        else
        {
            _activePoint= 0;
            
        }
    }
       
}
