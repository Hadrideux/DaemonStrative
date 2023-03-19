using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PNJMovement;

public class DialogueManager : Singleton<DialogueManager>
{
    #region Attributs

    [SerializeField] private Image _actorImage;
    [SerializeField] private TMPro.TextMeshProUGUI _actorName;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private RectTransform _backgroundBox;

    [SerializeField] private RectTransform _dialogueButton;
    [SerializeField] private DialogueController.Message[] _currentMessages;
    [SerializeField] private DialogueController.Actor[] _currentActors;
    [SerializeField] private int _activeMessage = 0;
    [SerializeField] private bool _isDialogueActive = false;

    #endregion Attributs

    #region Properties

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

    #endregion Properties

    public void OpenDialogue(DialogueController.Message[] messages, DialogueController.Actor[] actors)
    {
        _activeMessage = 0;
        _currentMessages = messages;
        _currentActors = actors;

        IsDialogueActive = true;
        CharacterManager.Instance.Agent.isStopped = true;

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
        _activeMessage = _activeMessage + 1;
        if (_activeMessage < _currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            IsDialogueActive = false;
            BackGroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            HideButton();
            /*if (CharacterManager.Instance.Agent.remainingDistance < 0.5f)
                CharacterManager.Instance.Agent.isStopped = false;*/
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
