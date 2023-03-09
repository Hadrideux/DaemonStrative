using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DialogueController;

public class DialogueManager : Singleton<DialogueManager>
{
    public Image _actorImage;
    public TMPro.TMP_Text _actorName;
    public TMPro.TMP_Text _messageText;
    public RectTransform _backgroundBox;

    private DialogueController.Message[] _currentMessage;
    private Actor[] _currentActor;
    private int _activeMessage = 0;

    public void OpenDialogue(DialogueController.Message[] messages, Actor[] actors)
    {
        _currentMessage = messages;
        _currentActor = actors;
        _activeMessage = 0;

        Debug.Log("Conversation Started" + messages.Length);

    }

    private void DisplayMessage()
    {
        DialogueController.Message messageToDisplay = _currentMessage[_activeMessage];
     
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
