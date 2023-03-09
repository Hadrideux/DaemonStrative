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
    public static bool isDialogueActive = false;

    public void OpenDialogue(DialogueController.Message[] messages, DialogueController.Actor[] actors)
    {
        _currentMessages = messages;
        _currentActors = actors;
        _activeMessage = 0;
        isDialogueActive = true;
        Debug.Log("Started Conversation !" + messages.Length);
        
    }

    private void DisplayMessage()
    {
        DialogueController.Message messageToDisplay = _currentMessages[_activeMessage];
        messageText.text = messageToDisplay.message;

        DialogueController.Actor actorToDisplay = _currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        _activeMessage++;
        if (_activeMessage < _currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation eneded!");
            isDialogueActive = false;
        }
    }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive == true)
            {
                NextMessage();
            }
        }

    
}
