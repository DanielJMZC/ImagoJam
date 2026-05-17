using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class NPCDialogueManager : MonoBehaviour
{
    public List<DialogueConversation> dialogueList = new List<DialogueConversation>();
    public DialogueConversation currentConversation;
    private bool hasSpokenToday = false;

    public bool IsConversationValid(DialogueConversation conversation)
    {
        return conversation.startingDialogue.MeetsConditions();
    }

    public bool IsConversationCompleted(DialogueConversation conversation)
    {
        return DialogueManager.Instance.HasCompletedConversation(conversation.conversationID);
    }

    public List<DialogueConversation> GetValidConversation()
    {
        List<DialogueConversation> validConversations = new List<DialogueConversation>();
        foreach (DialogueConversation conversation in dialogueList)
        {


            
            if (conversation.isFallback && IsConversationValid(conversation) && AreDependenciesMet(conversation))
            {
                validConversations.Add(conversation);
            }
            else if (IsConversationValid(conversation) && !IsConversationCompleted(conversation) && AreDependenciesMet(conversation))
            {
                validConversations.Add(conversation);
            }
        }

        return validConversations;
    }

    private DialogueConversation PickBestByPrioritiy(List<DialogueConversation> list)
    {
        if (list.Count == 0) return null;

        int highestPriority = list.Max(c => c.priority);
        List<DialogueConversation> highestPriorityConversations = list.Where(c => c.priority == highestPriority).ToList();

        return highestPriorityConversations[Random.Range(0, highestPriorityConversations.Count)];
    }

    public void AssignBestConversation()
    {
        List<DialogueConversation> valid = GetValidConversation();

        var main = valid.Where(c => !c.isFallback).ToList();
        var fallback = valid.Where(c => c.isFallback).ToList();

        if (main.Count > 0)
        {
            currentConversation = PickBestByPrioritiy(main);
        }
        else if (fallback.Count > 0)
        {
            currentConversation = PickBestByPrioritiy(fallback);
        }
        else
        {
            currentConversation = null;
        }


        hasSpokenToday = false;
        Debug.Log("Assigned Conversation: " + currentConversation?.conversationName);

    }

    public DialogueConversation GetCurrentConversation()
    {
        if (currentConversation == null)
        {
            return null;
        } else
        {
            return currentConversation;
        }  
    }

    public DialogueEntry GetStartingDialogue()
    {
        if (currentConversation == null)
        {
            return null;
        }

        if (!hasSpokenToday)
        {
            MarkSpoken();
            return currentConversation.startingDialogue;
        } else
        {
            return currentConversation.repeatDialogue;
        }

    }

    public void MarkSpoken()
    {
        hasSpokenToday = true;
    }
       
     public bool AreDependenciesMet(DialogueConversation conversation)
    {
        if (conversation.requiredConversations == null ||
            conversation.requiredConversations.Length == 0)
            return true;

        foreach (string id in conversation.requiredConversations)
        {
            if (!DialogueManager.Instance.HasCompletedConversation(id))
                return false;
        }

            return true;
    }
    
}