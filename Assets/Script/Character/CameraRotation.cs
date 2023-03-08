using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    [SerializeField] private Vector3 _offSet = Vector3.zero;
    [SerializeField] private float _angle = 90f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.LookAt(_target.transform.position);
    }

}
