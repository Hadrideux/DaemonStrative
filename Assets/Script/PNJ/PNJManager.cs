using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJManager : Singleton<PNJManager>
{
    [SerializeField] private PNJController _targetPnj = null;


    public PNJController TargetPnj
    {
        get => _targetPnj;

        set => _targetPnj = value;        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        DialogueManager.Instance.PNJDialogue();
        UIManager.Instance.DisplayUI();
    }
}
