using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _npcTarget;
    
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

    public void StartDialogue()
    {
        DialogueManager.Instance.OpenDialogue(messages, actors);
    }

    private void NPCLocation()
    {
        this.transform.position = new Vector3(_npcTarget.transform.position.x, _npcTarget.transform.position.y+1, _npcTarget.transform.position.z);
    }

    private void Start()
    {
        NPCLocation();
    }
}
