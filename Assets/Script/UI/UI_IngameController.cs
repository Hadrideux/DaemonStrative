using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [SerializeField] private Image _bloodImage = null;
    [SerializeField] private TextMeshProUGUI _bloodText = null;

    [SerializeField] private int _maxBlood = 0;
    [SerializeField] private RectTransform _fillBlood = null;

    private Vector3 _startPos = Vector3.zero;
    private Vector3 _endPos = Vector3.zero;

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
        _startPos.y = -_fillBlood.rect.width;

        UIManager.Instance.OmbreMarcheImage = _ombreMarcheImage;
        UIManager.Instance.MorsureImage = _morsureImage;
        UIManager.Instance.GriffureImage = _griffureImage;
    }

    // Update is called once per frame
    void Update()
    {
        _ombreMarcheText.text = UIManager.Instance.OmbreMarcheTimer.ToString("0");

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
        float perc = (float)InventoryManager.Instance.AmountBlood / _maxBlood;
        _fillBlood.localPosition = Vector3.Lerp(_startPos, _endPos, perc);
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