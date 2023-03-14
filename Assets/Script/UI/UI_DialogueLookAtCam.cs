using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DialogueLookAtCam : MonoBehaviour
{
    [SerializeField] private Camera _cameraTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(-_cameraTarget.transform.position);
    }
}