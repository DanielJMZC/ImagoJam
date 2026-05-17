using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

public class DialogueEntry
{
    [Header("NPC Information")]
    public Speaker speaker;
    public string emotionalState = "default";

    [Header("Dialogue Content")]
    [TextArea(3, 10)]
    public string dialogueText;

    [Header("Conditions")]
    public DialogueCondition[] conditions;

    public bool MeetsConditions()
    {
        if (conditions == null || conditions.Length == 0)
            return true;

        foreach (var condition in conditions)
        {
            if (!condition.Evaluate())
                return false;
        }
        return true;
    }

    [Header ("Audio")]
    public AudioClip voiceClip;

    [Header("Converation Flow")]
    public List<DialogueResponse> responses = new List<DialogueResponse>();

    public DialogueEntry nextDialogue;

    [Header("Events")]
    public bool endsConversation = false;
    public string eventToTrigger;

    public bool IsLinearDialogue()
    {
        return responses.Count == 0 && nextDialogue != null;
    }

    public bool HasChoices()
    {
        return responses.Count > 0;
    }

    public Sprite GetSpeakerPortrait()
    {
        if (speaker == null) return null;
        return speaker.GetPortraitForEmotion(emotionalState);
    }

    public string GetSpeakerName()
    {
        return speaker != null ? speaker.characterName : "Unknown";
    }
}