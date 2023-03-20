using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerFollow : MonoBehaviour
{

    [SerializeField] private Transform _characterRef = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private float _speed = 10f;
    [Range(0f,1f)]
    [SerializeField] private float _speedAlpha = 0.8f;

    private Vector3 targetRotation = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_characterRef.position.x, _characterRef.position.y + 10f, _characterRef.position.z);
        CameraAngle();
        
        // Rotation lerped
        Vector3 eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + targetRotation.y, transform.eulerAngles.z);
        Vector3 lerp = Vector3.Lerp(transform.eulerAngles, eulerAngles, _speedAlpha);
        transform.rotation = Quaternion.Euler(lerp);
        
        _camera.transform.LookAt(_characterRef.position);
    }

    private void CameraAngle()
    {
        targetRotation = new Vector3(0, Time.deltaTime * _speed  * Input.GetAxis("RotateCam"), 0);
    }

}
