using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{

    [SerializeField] private string _name = "ItemData";
    [SerializeField] private ERessourceType _type = ERessourceType.BLOOD;

    [SerializeField] private int _amount = 1;

    public string Name => _name;
    public ERessourceType Type => _type;
    public int Amount => _amount;   
}