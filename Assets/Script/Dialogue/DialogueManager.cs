using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Image _actorImage;
    public GameObject _actorName;
    public GameObject _messageText;
    public RectTransform _backgroundBox;

    private Message[] _currentMessage;
    private Actor[] _currentActor;
    private int _activeMessage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PNJDialogue()
    {

    }


}
