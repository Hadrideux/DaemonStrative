using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private PNJController _controllerPNJ = null;
    [SerializeField] private PNJDetection _detectionPNJ = null;
    [SerializeField] private PNJMovement _movementPNJ = null;

    [SerializeField] private GameObject _characterCompFeedback = null;
    [SerializeField] private GameObject _body = null;

    [SerializeField] private ItemData _itemData = null;

    [SerializeField] private GameObject _VFXSpawnPoint = null;
    private float _VFXDuration = 0;
    [SerializeField] private float _VFXEndTimer = 1;

    private bool _isCanSeePlayer = false;

    [SerializeField] private Animator _animator = null;

    #endregion Attributs

    #region Properties
    #region Controller

    public PNJDetection DetectionPNJ
    {
        get => _detectionPNJ;
        set => _detectionPNJ = value;
    }

    public PNJMovement MovementPNJ
    {
        get => _movementPNJ;
        set => _movementPNJ = value;
    }

    #endregion Controller

    public bool IsCanSeePlayer
    {
        get => _isCanSeePlayer;
        set => _isCanSeePlayer = value;
    }
    #endregion Properties

    #region Mono

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PNJManager.Instance.IsDead == true)
        {
            _VFXDuration += Time.deltaTime;

            if (_VFXDuration >= _VFXEndTimer) 
            {
                PNJManager.Instance.DestroyAll();
            }
        }
        else
        {
            _VFXDuration = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;
            PNJManager.Instance.ControllerPNJ = _controllerPNJ;

            _characterCompFeedback.SetActive(true);
        }
    }

    public void CastAnimation()
    {
        if (UIManager.Instance.IsClawSkillActive == true)
        {
            _animator.SetTrigger("DieByClaw");
            _characterCompFeedback.SetActive(false);
        }
        
        if (UIManager.Instance.IsBiteSkillActive == true)
        {
            _animator.SetTrigger("DieByBite");
            _characterCompFeedback.SetActive(false);
        }
    }
    #endregion Mono
}
