using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Image actorImage;
    public TMPro.TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    [SerializeField] RectTransform _dialogueButton;
    private DialogueController.Message[] _currentMessages;
    private DialogueController.Actor[] _currentActors;
    private int _activeMessage = 0;
    public static bool isDialogueActive = false;

    
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    public void OpenDialogue(DialogueController.Message[] messages, DialogueController.Actor[] actors)
    {
        _activeMessage = 0;
        _currentMessages = messages;
        _currentActors = actors;
        isDialogueActive = true;
        Debug.Log("Started Conversation !" + messages.Length);
        backgroundBox.LeanScale(Vector3.one, 0.5f);

        DialogueController.Message messageToDisplay = _currentMessages[_activeMessage];
        messageText.text = messageToDisplay.message;

        DialogueController.Actor actorToDisplay = _currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimatedTextColor();

        HideButton();
    }

    private void DisplayMessage()
    {
        DialogueController.Message messageToDisplay = _currentMessages[_activeMessage];
        messageText.text = messageToDisplay.message;

        DialogueController.Actor actorToDisplay = _currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimatedTextColor();
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
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            HideButton();
        }
    }
     
    private void AnimatedTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

       
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive == true)
            {
                NextMessage();
            }
        }

    private void HideButton()
    {
        if (isDialogueActive == true) 
        {
            _dialogueButton.gameObject.SetActive(false);
        }
        else if (isDialogueActive == false) 
        {
            _dialogueButton.gameObject.SetActive(true);
        }
    }
}
