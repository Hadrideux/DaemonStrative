using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    [SerializeField] private Vector3 _offSet = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _offSet = transform.position - _target.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target.position);
    }

}
