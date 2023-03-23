using UnityEngine;
using UnityEngine.AI;

public class PNJMovement : MonoBehaviour
{
    [SerializeField] private PNJController _controllerPNJ = null;
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int _activePoint = 0;

    [SerializeField] private bool _isGuard = false;

    private float _timeRef = 0;

    public float TimerRef
    {
        get => _timeRef;
        set => _timeRef = value;
    }

    public WayPoint[] _wayPoints;

    [System.Serializable]
    public class WayPoint
    {
        public GameObject target;
        public float waitTime;
    }


    // Update is called once per frame
    void Update()
    {
        Movement();        
    }

    private void Movement()
    {
        if (_isGuard == true && _controllerPNJ.IsCanSeePlayer == false)
        {

            if (agent.isStopped == true)
            {
                agent.isStopped = false;
            }

            if (agent.remainingDistance < 0.05f)
            {
                TimerRef += Time.deltaTime;
                WayPoint timer = _wayPoints[_activePoint];

                WalkRound();

                if (TimerRef > timer.waitTime && _activePoint < _wayPoints.Length)
                {
                    _activePoint = (_activePoint + 1) % _wayPoints.Length;
                    TimerRef = 0;
                }
                else if (TimerRef > timer.waitTime)
                {
                    _activePoint = 0;
                    TimerRef = 0;
                }
            }
        }
        else if (_controllerPNJ.IsCanSeePlayer == true)
        {
            agent.isStopped = true;

            Transform target = CharacterManager.Instance.Controller.transform;
            _controllerPNJ.transform.LookAt(target.position);
        }
    }
    private void WalkRound()
    {
        WayPoint actualPoint = _wayPoints[_activePoint];
        agent.SetDestination(actualPoint.target.transform.position);       
    }
}
