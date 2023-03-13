using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private Image _actorImage;
    [SerializeField] private TMPro.TextMeshProUGUI _actorName;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private RectTransform _backgroundBox;

    [SerializeField] private RectTransform _dialogueButton;
    [SerializeField] private DialogueController.Message[] _currentMessages;
    [SerializeField] private DialogueController.Actor[] _currentActors;
    [SerializeField] private int _activeMessage = 0;
    public static bool _isDialogueActive = false;

    public Image ActorImage
    {
        get => _actorImage;
        set => _actorImage = value;
    }
    public TextMeshProUGUI ActorName
    {
        get => _actorName;
        set => _actorName = value;
    }
    public TextMeshProUGUI MessageText
    {
        get => _messageText;
        set => _messageText = value;
    }
    public RectTransform BackGroundBox
    {
        get => _backgroundBox;
        set => _backgroundBox = value;
    }
    public bool IsDialogueActive
    {
        get => _isDialogueActive;
        set => _isDialogueActive = value;
    }

    public RectTransform DialogueButton
    {
        get => _dialogueButton;
        set => _dialogueButton = value;
    }

    
    void Start()
    {

    }

    public void OpenDialogue(DialogueController.Message[] messages, DialogueController.Actor[] actors)
    {
        _activeMessage = 0;
        _currentMessages = messages;
        _currentActors = actors;
        IsDialogueActive = true;
        Debug.Log("Started Conversation !" + messages.Length);
        BackGroundBox.LeanScale(Vector3.one, 0.5f);

        DialogueController.Message messageToDisplay = _currentMessages[_activeMessage];
        MessageText.text = messageToDisplay.message;

        DialogueController.Actor actorToDisplay = _currentActors[messageToDisplay.actorId];
        ActorName.text = actorToDisplay.name;
        ActorImage.sprite = actorToDisplay.sprite;
        AnimatedTextColor();

        HideButton();
    }

    private void DisplayMessage()
    {
        DialogueController.Message messageToDisplay = _currentMessages[_activeMessage];
        MessageText.text = messageToDisplay.message;

        DialogueController.Actor actorToDisplay = _currentActors[messageToDisplay.actorId];
        ActorName.text = actorToDisplay.name;
        ActorImage.sprite = actorToDisplay.sprite;
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
            IsDialogueActive = false;
            BackGroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            HideButton();
        }
    }
     
    private void AnimatedTextColor()
    {
        LeanTween.textAlpha(MessageText.rectTransform, 0, 0);
        LeanTween.textAlpha(MessageText.rectTransform, 1, 0.5f);
    }

       
     

    private void HideButton()
    {
        if (IsDialogueActive == true) 
        {
            _dialogueButton.gameObject.SetActive(false);
        }
        else if (IsDialogueActive == false) 
        {
            _dialogueButton.gameObject.SetActive(true);
        }
    }
}
