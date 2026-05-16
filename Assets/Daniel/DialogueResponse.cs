using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueResponse
{
    [TextArea(2,5)]
    public string responseText;
    public DialogueEntry nextDialogue;

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

    public bool requiresEvent = false;
    public string requiredEventID;

}