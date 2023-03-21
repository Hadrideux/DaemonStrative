using UnityEngine;
using UnityEngine.UI;


public class PNJController : MonoBehaviour
{

    #region Attributs

    [SerializeField] private PNJController _controllerPNJ = null;
    [SerializeField] private PNJDetection _detectionPNJ = null;
    //[SerializeField] private PNJMovement _pNJMovement = null;
    
    [SerializeField] private GameObject _characterCompFeedback = null;
    [SerializeField] private GameObject _body = null;

    [SerializeField] private ItemData _itemData = null;

    [SerializeField] private GameObject _VFXSpawnPoint = null;
    private float _VFXDuration = 0;
    [SerializeField] private float _VFXEndTimer = 1;

    private bool _isCanSeePlayer = false;
    //[SerializeField] private Image _detectionGauge = null;

    #endregion Attributs

    #region Properties
        #region Controller
    
    public PNJController ControllerPNJ
    {
        get => _controllerPNJ;
        set => _controllerPNJ = value;
    }
    public PNJDetection DetectionPNJ
    {
        get => _detectionPNJ;
        set => _detectionPNJ = value;
    }
    /*
    public PNJMovement MovementPNJ
    {
        get => _pNJMovement;
        set => _pNJMovement = value;
    }
    */

    #endregion Controller
    /*
    public Image DetectionGauge
    {
        get => _detectionGauge;
        set => _detectionGauge = value;
    }
    */
    public bool IsCanSeePlayer
    {
        get => _isCanSeePlayer;
        set => _isCanSeePlayer = value;
    }

    #endregion Properties

    #region Mono

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PNJManager.Instance.ItemGet = _itemData;
            PNJManager.Instance.VFXSpawner = _VFXSpawnPoint;
            PNJManager.Instance.Body = _body;

            _characterCompFeedback.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        PNJManager.Instance.ItemGet = null;
        PNJManager.Instance.VFXSpawner = null;
        PNJManager.Instance.Body = null;

        _characterCompFeedback.SetActive(false);

    }

    private void Update()
    {

        if (PNJManager.Instance.IsDead == true)
        {
            _VFXDuration += Time.deltaTime;

            if (_VFXDuration > _VFXEndTimer) 
            { 
                PNJManager.Instance.DestroyAll();
            }
        }
        else
        {
            _VFXDuration = 0;
        }
        /*
        if(IsCanSeePlayer == true && _detectionGauge != null) 
        {
            Detection();        
        }
        else if(IsCanSeePlayer == false && _detectionGauge != null) 
        {
            Undetecte();
        }
        */
    }
    #endregion Mono

    private void Detection()
    {
        //DetectionGauge.fillAmount += DetectionPNJ.DetectionFeedBack / 2 * Time.deltaTime;
    }
    private void Undetecte()
    {
        //DetectionGauge.fillAmount -= DetectionPNJ.DetectionFeedBack / 2 * Time.deltaTime;
    }
}
