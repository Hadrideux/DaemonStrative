using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapViewUI : MonoBehaviour
{
    private float _BloodAmount = 0;
    private float _SkullAmount = 0;
    [SerializeField] private TextMeshProUGUI _BloodCompletion = null;
    [SerializeField] private TextMeshProUGUI _SkullCompletion = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string s = string.Format("{0}{1}", _BloodAmount, "/15");
        _BloodAmount = InventoryManager.Instance.AmountBlood;
        _BloodCompletion.text = s;

        string t = string.Format("{0}{1}", _SkullAmount, "/1");
        _SkullAmount = InventoryManager.Instance.AmountSkull;
        _SkullCompletion.text = t;
    }
}
