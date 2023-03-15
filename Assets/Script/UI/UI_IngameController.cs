using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Image _bloodImage = null;
    [SerializeField] private TextMeshProUGUI _bloodText = null;

    [SerializeField] private Image _skullImage = null;
    [SerializeField] private TextMeshProUGUI _skullText = null;

    #endregion Item

    #region Blood

    [SerializeField] private int _maxBlood = 0;
    [SerializeField] private RectTransform _fillBlood = null;

    private Vector3 _startPos = Vector3.zero;
    private Vector3 _endPos = Vector3.zero;

    #endregion Blood

    #region Suspicious

    [SerializeField] private Image _fillsuspicious = null;

    [Range(0f, 1f)]
    [SerializeField] private float _fillProgress = 0;

    #endregion Suspicious

    #endregion Attributs

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        _startPos.y = -_fillBlood.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        _ombreMarcheText.text = UIManager.Instance.OmbreMarcheTimer.ToString("0");

        _bloodText.text = InventoryManager.Instance.AmountBlood.ToString();
        _skullText.text = InventoryManager.Instance.AmountSkull.ToString(); 

        UpdateBlood();
        UpdateSuspicious();
    }

    #endregion MONO

    public void UpdateBlood()
    {
        float perc = (float)InventoryManager.Instance.AmountBlood / (float)_maxBlood;
        _fillBlood.localPosition = Vector3.Lerp(_startPos, _endPos, perc);
    }

    public void UpdateSuspicious()
    {
        _fillsuspicious.fillAmount = _fillProgress;
    }

}