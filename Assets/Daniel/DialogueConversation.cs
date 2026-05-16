using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Conversation")]
public class DialogueConversation: ScriptableObject
{
    [Header("Conversation Info")]
    public string conversationID;
    public string conversationName;

    [Header("Dialogue Entries")]
    public DialogueEntry startingDialogue;

    [Header("Repeatable Dialogue")]
    public bool canRepeat = true;
    public DialogueEntry repeatDialogue;

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