using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Conversation")]
public class DialogueConversation: ScriptableObject
{
    [Header("Conversation Info")]
    public string conversationID;
    public string conversationName;
    public int priority;

    [Header("Dialogue Entries")]
    public DialogueEntry startingDialogue;

    [Header("Repeatable Dialogue")]
    public bool isFallback = true;
    public bool canRepeat = true;
    public DialogueEntry repeatDialogue;
    [Header("Dependencies")]
    public string[] requiredConversations;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(conversationID))
        {
            conversationID = name;
        }
    }

    public DialogueEntry GetStartingDialogue(bool hasBeenCompleted)
    {
        if (hasBeenCompleted && !canRepeat && repeatDialogue != null)
        {
            return repeatDialogue;
        }

        return startingDialogue;
    }

}