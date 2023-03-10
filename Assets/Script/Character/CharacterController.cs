using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;


    #endregion Attributs



    void Start()
    {
        CharacterManager.Instance.Controller = this;
        PNJDetections.Instance.PlayerRef = this;
        //PNJManager.Instance.Target = transform;

        CharacterManager.Instance.Agent = _agent;
        CharacterManager.Instance.Camera = _camera;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           CharacterManager.Instance.Moving(/*_camera, _agent*/);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.Morsure();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.Griffe();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterManager.Instance.Shadowalk();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CharacterManager.Instance.IsInBack();
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        //D�truit que le trigger du dos des pnjs
        CharacterManager.Instance.Collider = other.gameObject; 
    }

}
