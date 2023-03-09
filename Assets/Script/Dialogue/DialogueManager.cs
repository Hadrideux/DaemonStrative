using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Image actorImage;
    public TMPro.TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    private DialogueController.Message[] _currentMessages;
    private DialogueController.Actor[] _currentActors;
    private int _activeMessage = 0;

    public void OpenDialogue(DialogueController.Message[] messages, DialogueController.Actor[] actors)
    {
        _currentMessages = messages;
        _currentActors = actors;
        _activeMessage = 0;

        Debug.Log("Started Conversation !" + messages.Length);
        
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
