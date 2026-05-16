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


        switch (conditionType)
        {
            case ConditionType.RelationshipLevel:
                result = RelationshipManager.Instance?.GetRelationship(conditionID) >= requiredValue;
                break;
            
        }

        return invertCondition ? !result : result;

    }
    
}