using UnityEngine;
using UnityEngine.AI;

public class CharacterConrtoller : MonoBehaviour
{
    #region Attributs

    
    [SerializeField] private CharacterMovement _characterMove = null;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;
    [SerializeField] private AudioSource _audioSource = null;

    [SerializeField] private GameObject[] _typeVFX = null;
    [SerializeField] private GameObject _VFXOmbremarche = null;

    [SerializeField] private AudioClip[] _skillsSFX = null;

    [SerializeField] private GameObject virtualCam = null;
    [SerializeField] private float animTimer = 0;
    [SerializeField] private float animDelay = 5;
    [SerializeField] private float timeCount = 0;
    [SerializeField] private bool onActivation = false;

    [SerializeField] private Animator _animationDetection = null;

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
    public Animator AnimationDetection
    {
        get => _animationDetection;
        set => _animationDetection = value;
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
        SwitchCam(animTimer, animDelay, virtualCam);

        if (Input.GetMouseButton(1))
        {
            _characterMove.MovingAction();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterManager.Instance.SkillsVFX = _typeVFX[0];
            _audioSource.PlayOneShot(_skillsSFX[0], 1f);

            CharacterManager.Instance.BiteAction();
            onActivation= true;
            timeCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.SkillsVFX = _typeVFX[1]; 
            _audioSource.PlayOneShot(_skillsSFX[1], 3f);

            CharacterManager.Instance.ClawAction();
            onActivation = true;
            timeCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterManager.Instance.ShadoStepAction();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.Instance.NextMessage();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.AmountBlood = 100;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            WitchManager.Instance.IsQuestOmbreMarche = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.pauseGame();
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
        if (other.CompareTag("PNJ"))
        {
            CharacterManager.Instance.Collider = null;
        }
    }

    private void SwitchCam(float timeCount, float animDelay, GameObject virtualCam)
    {                
        if (onActivation == true)
        {
            virtualCam.SetActive(true);
            animTimer = timeCount += Time.deltaTime;
        }
        if (animTimer >= animDelay)
        {
            onActivation = false;
            virtualCam.SetActive(false);
            animTimer = 0;
        }
    }

}
