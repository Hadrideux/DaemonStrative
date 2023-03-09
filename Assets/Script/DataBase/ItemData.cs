using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{

    [SerializeField] private string _name = "ItemData";
    [SerializeField] private EPNJType _origin = EPNJType.SORCIERE;
    [SerializeField] private ERessourceType _type = ERessourceType.SANG;

    [SerializeField] private int _amount = 1;
    //[SerializeField] private bool _isPickUp = false;

    public string Name => _name;
    public EPNJType Origin => _origin;
    public ERessourceType Type => _type;
    public int Amount => _amount;   

    //public bool IsPickUp => _isPickUp;

}