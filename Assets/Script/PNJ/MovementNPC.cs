using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class MovementNPC : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float _waitTime = 0;
    private int _activePoint = 0;
    private float _timePatrol = 0;

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
        WalkRound();
    }

    private void WalkRound()
    {
        
        WayPoint actualPoint = _wayPoints[_activePoint];
        _timePatrol += Time.deltaTime;

        if(actualPoint != null && _waitTime > _timePatrol) 
        {

            agent.SetDestination(actualPoint.target.transform.position);
           
        }
        else if (_waitTime < _timePatrol && _activePoint < _wayPoints.Length-1)
        {
            _activePoint += 1;
            _timePatrol = 0;
            WalkRound();

            Debug.Log(_activePoint.ToString());
        }
        else
        {
            _activePoint= 0;
            WalkRound();
        }
    }
       
}
