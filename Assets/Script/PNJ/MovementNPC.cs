using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class MovementNPC : MonoBehaviour
{
    
    [SerializeField] private float _waitTime = 0;
    private int _activePoint = 0;

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
        
    }

    private void WalkRound()
    {
        WayPoint actualPoint = _wayPoints[_activePoint];
        WayPoint nextPoint = _wayPoints[_activePoint + 1];
        Vector3.MoveTowards(actualPoint.target.transform.position, nextPoint.target.transform.position, 0);
    }
}
