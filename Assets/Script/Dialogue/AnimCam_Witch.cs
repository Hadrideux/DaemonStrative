using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCam_Witch : MonoBehaviour
{
    [SerializeField] private GameObject[] _virtualCam;
    [SerializeField] private DialogueController.Actor[] _currentActors;
    [SerializeField] private int _activeCam = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.Instance.IsDialogueActive == true)
        {
            SwitchCamOnSpeaker(_currentActors);
        }
        else
        {

        }
    }

    private void SwitchCamOnSpeaker(DialogueController.Actor[] actors)
    {
       
        
    }
}
