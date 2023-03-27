using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_IngameController : MonoBehaviour
{
    #region Attributs
    #region Competence
    
    [SerializeField] private Image _morsureImage = null;
    
    [SerializeField] private Image _griffureImage = null;
    
    [SerializeField] private Image _ombreMarcheImage = null;
    [SerializeField] private TextMeshProUGUI _ombreMarcheText = null;

    #endregion Competence

    #region Item

    [SerializeField] private Image _skullImage = null;
    [SerializeField] private TextMeshProUGUI _skullText = null;

    #endregion Item

    #region Blood

    [SerializeField] private Image _fillBlood = null;
    [SerializeField] private TextMeshProUGUI _bloodText = null;
    [SerializeField] private int _maxBlood = 100;

    #endregion Blood

    #region Suspicious

    [SerializeField] private Sprite[] _suspiciousSprite = null;
    [SerializeField] private Image _suspiciousImage = null;
    private int _index = 0;

    #endregion Suspicious

    #endregion Attributs

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShadowStepImage = _ombreMarcheImage;
        UIManager.Instance.BiteImage = _morsureImage;
        UIManager.Instance.ClawImage = _griffureImage;
    }

    // Update is called once per frame
    void Update()
    {
        _ombreMarcheText.text = UIManager.Instance.ShadowStepTimer.ToString("0");

        _bloodText.text = Mathf.Clamp(InventoryManager.Instance.AmountBlood, 0, _maxBlood).ToString();
        _skullText.text = InventoryManager.Instance.AmountSkull.ToString();    

        if (_skullText.text == "0")
        {
            _skullImage.color = new Color(_skullImage.color.r, _skullImage.color.g, _skullImage.color.b, 0.5f);
        }
        else
        {
            _skullImage.color = new Color(_skullImage.color.r, _skullImage.color.g, _skullImage.color.b, 1f);
        }

        UpdateBlood();
        UpdateSuspicious();
    }

    #endregion MONO

    public void UpdateBlood()
    {
        _fillBlood.fillAmount += Mathf.Clamp(InventoryManager.Instance.AmountBlood, 0, _maxBlood);
    }

    public void UpdateSuspicious()
    {
        _suspiciousImage.sprite = _suspiciousSprite[_index];

        if (Input.GetKeyDown(KeyCode.KeypadPlus) )
        {
            _index++;
        }
    }
}