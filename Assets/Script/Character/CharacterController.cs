using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    
    [SerializeField] private CharacterMovement _characterMove = null;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;

    [SerializeField] private GameObject[] _typeVFX = null;
    [SerializeField] private GameObject _VFXOmbremarche = null;

    [SerializeField] private AudioClip[] _skillsSFX = null;

    #endregion Attributs

    public NavMeshAgent Agent
    {
        get => _agent;
        set => _agent = value;
    }
    public Camera Camera
    {
        get => _camera;
        set => _camera = value;
    }

    void Start()
    {
        CharacterManager.Instance.Controller = this;

        CharacterManager.Instance.Agent = Agent;
        CharacterManager.Instance.Camera = Camera;
        CharacterManager.Instance.VFXOmbremarche = _VFXOmbremarche;
    }
    void Update()
    {        
        if (Input.GetMouseButton(1))
        {
            _characterMove.Moving();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.SkillsVFX = _typeVFX[0];
            CharacterManager.Instance.SkillsSFX = _skillsSFX[0];

            UIManager.Instance.IsMorsureCast = true;
            CharacterManager.Instance.Morsure();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.SkillsVFX = _typeVFX[1];
            CharacterManager.Instance.SkillsSFX = _skillsSFX[1];

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
