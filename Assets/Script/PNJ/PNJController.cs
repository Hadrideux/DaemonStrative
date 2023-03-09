using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PNJController : Singleton<PNJController>
{

    [SerializeField] private GameObject _interactUI = null;

    #region Mono

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    #endregion Mono
    public void UIInteract(bool value)
    {
        _interactUI.SetActive(value);
        //Display de l'ui d'interaction
    }
}
