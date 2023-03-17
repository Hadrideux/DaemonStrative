using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
//using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class PNJMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float _timeRef = 0;

    [SerializeField] private int _activePoint = 0;
    
    [SerializeField] private bool _isGuard = false;
    
    public WayPoint[] _wayPoints;

    [System.Serializable]
    public class WayPoint
    {
        public GameObject target;
        public float waitTime;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        _activePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGuard == true && PNJDetection.Instance.IsCanSeePlayer == false)
        {
            if(agent.isStopped == true)
            {
                agent.isStopped = false;
            }
            
            if(agent.remainingDistance < 0.05f)
            {
                _timeRef += Time.deltaTime;
                WayPoint timer = _wayPoints[_activePoint];

                WalkRound();

                if (_timeRef > timer.waitTime && _activePoint < _wayPoints.Length)
                {                    
                    _activePoint = (_activePoint + 1) % _wayPoints.Length;
                    _timeRef = 0;
                    Debug.Log(_activePoint.ToString());
                }
                else if (_timeRef > timer.waitTime)
                {
                    _activePoint = 0;
                    _timeRef = 0;
                    Debug.Log("ResetMove");
                }
                
                                
            }
        }
        else if (PNJDetection.Instance.IsCanSeePlayer == true)
        {
            agent.isStopped= true;
        }
        
    }

    private void WalkRound()
    {
        WayPoint actualPoint = _wayPoints[_activePoint];
        agent.SetDestination(actualPoint.target.transform.position);       
    }

}
