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
    [SerializeField] private int _activePoint = 0;

    [SerializeField] private bool _isGuard = false;
    
    [SerializeField] private float _timeRef = 0;

    [SerializeField] private PNJController _pNJController = null;

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
        PNJController controller = _pNJController;
        Debug.Log(controller.DetectionPNJ.IsCanSeePlayer);

        if (_isGuard == true && controller.DetectionPNJ.IsCanSeePlayer == false)
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
                }
                else if (_timeRef > timer.waitTime)
                {
                    _activePoint = 0;
                    _timeRef = 0;
                }       
            }
        }
        else if (controller.DetectionPNJ.IsCanSeePlayer == true)
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
