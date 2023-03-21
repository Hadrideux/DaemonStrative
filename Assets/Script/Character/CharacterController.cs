using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    [SerializeField] private GameObject[] _VFXType = null;
    [SerializeField] private GameObject _VFXOmbremarche = null;
    [SerializeField] private GameObject _VFXHitPoint = null;
    
    
    #endregion Attributs

    public GameObject VFXHitPoint
    {
        get => _VFXHitPoint;
        set => _VFXHitPoint = value;
    }

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.VFXSkills = _VFXType[0];
            UIManager.Instance.IsMorsureCast = true;
            CharacterManager.Instance.Morsure();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.VFXSkills = _VFXType[1];
            UIManager.Instance.IsGriffureCast = true;
            CharacterManager.Instance.Griffe();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && WitchManager.Instance.IsQuestOmbreMarche == true)
        {
            CharacterManager.Instance.Shadowalk();
        }

        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialogueActive == true)
        {
            DialogueManager.Instance.NextMessage();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.AmountBlood = 100;
            //InventoryManager.Instance.AmountSkull = 1;
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

    private void OnTriggerExit(Collider other)
    {
       
    }

}
