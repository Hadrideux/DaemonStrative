using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Image _actorImage;
    [SerializeField] private TMPro.TextMeshProUGUI _actorName;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private RectTransform _backgroundBox;
    [SerializeField] private RectTransform _dialogueButton;

    public Message[] messages;
    public Actor[] actors;

    [System.Serializable]
    public class Message
    {
        public int actorId;
        public string message;
    }

    
    [System.Serializable]
    public class Actor
    {
        public string name;
        public Sprite sprite;
    }

    void Start()
    {
        _backgroundBox.transform.localScale = Vector3.zero;

        DialogueManager.Instance.ActorImage = _actorImage;
        DialogueManager.Instance.ActorName = _actorName;
        DialogueManager.Instance.MessageText = _messageText;
        DialogueManager.Instance.BackGroundBox = _backgroundBox;
        DialogueManager.Instance.DialogueButton = _dialogueButton;
    }

    public void StartDialogue()
    {
        DialogueManager.Instance.OpenDialogue(messages, actors);
        Debug.Log("jkbbkjbjb");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialogueActive == true)
        {
            DialogueManager.Instance.NextMessage();
        }
    }







}
