using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerFollow : MonoBehaviour
{

    [SerializeField] private GameObject _characterRef = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_characterRef.transform.position.x, _characterRef.transform.position.y + 10f, _characterRef.transform.position.z);
        CameraAngle();
    }

    private void CameraAngle()
    {
        if (Input.GetKey(KeyCode.Q))
        {
           
            transform.Rotate(0,1,0);
            Debug.Log("turn");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,-1, 0);
            Debug.Log("turn");
        }
    }

}
