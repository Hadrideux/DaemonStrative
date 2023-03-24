using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCam_Witch : MonoBehaviour
{
    [SerializeField] private DialogueController.Actor[] _currentActors;
    
    [SerializeField] private int _activeMessage = 0;
    [SerializeField] private int _activeActor = 0;


    public VirtualCams[] virtualCams;

    [System.Serializable]
    public class VirtualCams
    {
        public GameObject virtualcam;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.Instance.IsDialogueActive == true)
        {
            EnableCamSpeaker(virtualCams);
        }
        else
        {
            DisableCamSpeaker(virtualCams);
        }
    }

   private void EnableCamSpeaker(VirtualCams[] virtualCams)
    {
        VirtualCams activeCam = virtualCams[DialogueManager.Instance.ActiveMessage];
        activeCam.virtualcam.gameObject.SetActive(true);       
    }

    private void DisableCamSpeaker(VirtualCams[] virtualCams)
    {
        VirtualCams activeCam = virtualCams[DialogueManager.Instance.ActiveMessage];
        activeCam.virtualcam.gameObject.SetActive(false);
    }
}
