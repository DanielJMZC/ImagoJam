using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public static RelationshipManager Instance;

    public int relationshipValue = 10;

    public void Awake()
    {
        Instance = this;
    }

    public int GetRelationship(string id)
    {
        Debug.Log("" + id);
        return relationshipValue;
    }
}