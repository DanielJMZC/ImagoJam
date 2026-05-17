using UnityEngine;

public enum ConditionType
{
    RelationshipLevel,
    HungerValue,
    ThirstValue,
    SanityValue,
    AliveStatus,
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
            case ConditionType.HungerValue:
            {
                if(int.TryParse(conditionID.Trim(), out int survivorID)) {
                    Debug.Log("Evaluating Hunger Condition for Survivor ID: " + survivorID);
                    result = GlobalController.Instance?.GetSurvivor(survivorID)?.getHunger() <= requiredValue;
                }
                break;
            }

            case ConditionType.ThirstValue:
            {
                if(int.TryParse(conditionID.Trim(), out int survivorID)) {
                    Debug.Log("Evaluating Thirst Condition for Survivor ID: " + survivorID);
                    result = GlobalController.Instance?.GetSurvivor(survivorID)?.getThirst() <= requiredValue;
                }
                break;
            }

            case ConditionType.SanityValue:
            {
                if(int.TryParse(conditionID.Trim(), out int survivorID)) {
                    result = GlobalController.Instance?.GetSurvivor(survivorID)?.getSanity() <= requiredValue;
                }
                break;
            }

            case ConditionType.AliveStatus:
            {
                if(int.TryParse(conditionID.Trim(), out int survivorID)) {
                    result = GlobalController.Instance?.GetSurvivor(survivorID)?.getAlive() == (requiredValue == 1);
                }
                break;
            }

        }

        return invertCondition ? !result : result;

    }
    
}