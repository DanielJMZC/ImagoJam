using UnityEngine;

public enum ConditionType
{
    RelationshipLevel,
    GameFlag
}

[System.Serializable]
public class DialogueCondition
{
    public ConditionType conditionType;
    public string conditionID;
    public int requiredValue = 0;
    public bool invertCondition = false;

    public bool Evaluate()
    {
        bool result = false;

/*
        switch (conditionType)
        {
            case ConditionType.HasQuest:
                result = QuestManager.Instance?.HasQuest(conditionID) ?? false;
                break;
            case ConditionType.QuestCompleted:
                result = QuestManager.Instance?.IsQuestCompleted(conditionID) ?? false;
                break;
            case ConditionType.HasItem:
                result = InventoryManager.Instance?.HasItem(conditionID, requiredValue) ?? false;
                break;
            case ConditionType.RelationshipLevel:
                result = RelationshipManager.Instance?.GetRelationship(conditionID) >= requiredValue;
                break;
            case ConditionType.GameFlag:
                result = GameStateManager.Instance?.GetFlag(conditionID) ?? false;
                break;
        }

        return invertCondition ? !result : result;

        */

        return false;
    }
    
}