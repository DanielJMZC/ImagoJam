using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance {get; private set;}

    [Header ("UI Reference")]
    public DialogueUI dialogueUI;

    [Header("State")]
    private DialogueConversation currentConversation;
    private DialogueEntry currentDialogue;
    private bool isInDialogue = false;

    [Header("Completed Conversations")]
    private HashSet<string> completedConversations = new HashSet<string>();

    [Header("Events")]
    public UnityEvent<string> OnDialogueEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void StartConversation(DialogueConversation conversation, DialogueEntry dialogueEntry)
    {
        if (isInDialogue) return;

        currentConversation = conversation;
        bool hasCompleted = completedConversations.Contains(conversation.conversationID);
        currentDialogue = dialogueEntry;
        Debug.Log("WEEE");

        isInDialogue = true;
        dialogueUI.Show();
        DisplayCurrentDialogue();
    }

    private void DisplayCurrentDialogue()
    {
        if (currentDialogue == null)
        {
            EndConversation();
            return;
        }

        if (currentDialogue.voiceClip != null)
        {
            dialogueUI.PlayVoiceClip(currentDialogue.voiceClip);
        }

        dialogueUI.SetSpeakerName(currentDialogue.speaker.characterName);
        dialogueUI.SetSpeakerPortrait(currentDialogue.speaker.defaultPortrait);
        dialogueUI.SetDialogueText(currentDialogue.dialogueText);

        if (currentDialogue.HasChoices())
        {
            dialogueUI.ShowChoices(currentDialogue.responses);
        } else
        {
            dialogueUI.ShowContinueButton();
        }

        if (currentDialogue.endsConversation)
        {
            dialogueUI.SetupConversationEnd();
        }
    }

    public void SelectResponse(int responseIndex)
    {
        if (!isInDialogue || !currentDialogue.HasChoices()) return;

        if (responseIndex < 0 || responseIndex >= currentDialogue.responses.Count) return;

        DialogueResponse selectedResponse = currentDialogue.responses[responseIndex];
        currentDialogue = selectedResponse.nextDialogue;
        DisplayCurrentDialogue();
    }

    public void ContinueDialogue()
    {
        if (!isInDialogue) return;

        if (currentDialogue.endsConversation)
        {
            EndConversation();
            return;
        }

        if (currentDialogue.IsLinearDialogue())
        {
            currentDialogue = currentDialogue.nextDialogue;
            DisplayCurrentDialogue();
        }
    }

    private void EndConversation()
    {
        if (!string.IsNullOrEmpty(currentDialogue?.eventToTrigger))
        {
            OnDialogueEvent?.Invoke(currentDialogue.eventToTrigger);
        }

        if (currentConversation != null)
        {
            completedConversations.Add(currentConversation.conversationID);
        }

        dialogueUI.Hide();
        isInDialogue = false;
        currentConversation = null;
        currentDialogue = null;
        
    }

    public bool IsInDialogue()
    {
        return isInDialogue;
    }

    public bool HasCompletedConversation(string conversationID)
    {
        return completedConversations.Contains(conversationID);
    }
}