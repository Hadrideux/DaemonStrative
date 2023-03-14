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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_characterRef.position.x, _characterRef.position.y + 10f, _characterRef.position.z);
        CameraAngle();
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + targetRotation, _speedAlpha); 
        _camera.transform.LookAt(_characterRef.position);
    }

    private void CameraAngle()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(0,1,0);
            targetRotation += new Vector3(0, Time.deltaTime * _speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0,-1, 0);
            targetRotation -= new Vector3(0, Time.deltaTime * _speed, 0);
        }
    }

}
