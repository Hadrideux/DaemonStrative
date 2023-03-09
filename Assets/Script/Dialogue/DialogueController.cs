using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    [System.Serializable]
    public class Message
    {
        public int actorID;
        public string text;
    }

    [System.Serializable]
    public class Actor
    {
        public string text;
        public Sprite sprite;
    }

}
