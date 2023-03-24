using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCam_Witch : MonoBehaviour
{
    public VirtualCams[] virtualCams;
    private int _activeCam = 0;
    private int _camToDisable = 0;

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
        if (DialogueManager.Instance.IsDialogueActive == true)
        {
            EnableCamSpeaker(virtualCams);
            DisableCamSpeaker(virtualCams);            
        }
        else
        {
            DisableSwitchCam();
        }
    }

   private void EnableCamSpeaker(VirtualCams[] virtualCams)
    {
        _activeCam = DialogueManager.Instance.ActiveMessage;

        VirtualCams activeCam = virtualCams[_activeCam];
        activeCam.virtualcam.gameObject.SetActive(true);
   }

    private void DisableCamSpeaker(VirtualCams[] virtualCams)
    {
        _camToDisable = DialogueManager.Instance.ActiveMessage-1;

        if (_camToDisable >= 0 && _activeCam <= virtualCams.Length)
        {
            VirtualCams activeCam = virtualCams[_camToDisable];
            activeCam.virtualcam.gameObject.SetActive(false);
        }
        
    }

    private void DisableSwitchCam()
    {
        VirtualCams activeCam = virtualCams[_activeCam];
        if (activeCam.virtualcam.gameObject == true && DialogueManager.Instance.IsDialogueActive == false)
        {
            activeCam.virtualcam.gameObject.SetActive(false);
        }
    }
}
