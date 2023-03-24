using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapViewUI : MonoBehaviour
{
    [SerializeField] private float _BloodAmount = 0;
    [SerializeField] private TextMeshProUGUI _BloodCompletion = null;
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
    }
}
