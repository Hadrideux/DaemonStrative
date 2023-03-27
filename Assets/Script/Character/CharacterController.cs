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

    [SerializeField] private bool onActivation = false;

    [SerializeField] private GameObject _mapCamView = null;
    [SerializeField] private GameObject _UIpCharacter= null;
    [SerializeField] private bool _isMapEnable = false;
    

    [SerializeField] private Animator _animationDetection = null;
    [SerializeField] private Animator _animationCharacter = null;


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
    public Animator AnimationCharacter
    {
        get => _animationCharacter;
        set => _animationCharacter = value;
    }

    void Start()
    {
        CharacterManager.Instance.Controller = this;

        CharacterManager.Instance.Agent = Agent;
        CharacterManager.Instance.Camera = Camera;

        AnimationDetection.gameObject.SetActive(false);

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

            AnimationCharacter.SetTrigger("Bite");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterManager.Instance.SkillsVFX = _typeVFX[1]; 
            _audioSource.PlayOneShot(_skillsSFX[1], 3f);

            CharacterManager.Instance.ClawAction();
            onActivation = true;

            AnimationCharacter.SetTrigger("Claw");
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddItem();
        }
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            if (_isMapEnable == false)
            {
                EnableMapView();
                
            }
            else if (_isMapEnable == true)
            {
                RemoveMapView();
                
            }
            
        }

        //Vector3 destination = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward; //0f <> 1f
        //if(Input.GetButtonDown("Fire1")
    }
    /*
    public void AudioDetected(bool isDetected)
    {
        if (isDetected)
        {
            _audioSource.enabled = true;
            Debug.Log(_audioSource.clip.length);
            _audioSource.PlayOneShot(_skillsSFX[2], 1f);
        }
        else
        {
            _audioSource.Stop();
        }
        
    }
    */
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

    private void EnableMapView()
    {
        _isMapEnable = true;
        _UIpCharacter.gameObject.SetActive(false);
        _mapCamView.gameObject.SetActive(true);
    }

    private void RemoveMapView ()
    {
        _isMapEnable = false;
        _UIpCharacter.gameObject.SetActive(true);
        _mapCamView.gameObject.SetActive(false);
    }
}
