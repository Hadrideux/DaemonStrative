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
    [SerializeField] private GameObject _VFXOmbremarche = null;
    [SerializeField] private GameObject _VFXHitPoint = null;

    #endregion Attributs


    void Start()
    {
        CharacterManager.Instance.Controller = this;

        CharacterManager.Instance.Agent = _agent;
        CharacterManager.Instance.Camera = _camera;
        CharacterManager.Instance.VFXOmbremarche = _VFXOmbremarche;
        CharacterManager.Instance.VFXHitPointNavigation = _VFXHitPoint;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
           CharacterManager.Instance.Moving();
        }
        CharacterManager.Instance.EndMovement();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.VFXSkills = _VFXMorsure;            
            CharacterManager.Instance.Morsure();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.VFXSkills = _VFXGriffure;
            PNJManager.Instance.isDead = true;
            CharacterManager.Instance.Griffe();            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterManager.Instance.Shadowalk();
            UIManager.Instance.IsCast = true;

        }

        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialogueActive == true)
        {

            DialogueManager.Instance.NextMessage();
        }
                
        //Vector3 destination = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward; //0f <> 1f
        //if(Input.GetButtonDown("Fire1")
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PNJ"))
        {
            CharacterManager.Instance.Collider = other.gameObject;
        }
    }

  
}
