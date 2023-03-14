using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private GameObject _VFXMorsure = null;
    [SerializeField] private GameObject _VFXGriffure = null;

    #endregion Attributs


    void Start()
    {
        CharacterManager.Instance.Controller = this;

        CharacterManager.Instance.Agent = _agent;
        CharacterManager.Instance.Camera = _camera;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
           CharacterManager.Instance.Moving();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.VFXType = _VFXMorsure;            
            CharacterManager.Instance.Morsure();           
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.VFXType = _VFXGriffure;
            PNJManager.Instance.isDead = true;
            CharacterManager.Instance.Griffe();            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterManager.Instance.Shadowalk();
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            gameObject.layer = LayerIgnoreRaycast;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterManager.Instance.Collider = other.gameObject;
    }
}
