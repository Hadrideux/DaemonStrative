using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    [SerializeField] private Vector3 _offSet = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _offSet = transform.position - _target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraAngle();
        transform.LookAt(_target.transform.position);
    }

    private void CameraAngle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.RotateAround(_target.transform.position, Vector3.up, 90f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.RotateAround(_target.transform.position, Vector3.up, -90f);
        }
        transform.position = _target.transform.position + _offSet;
    }
}
