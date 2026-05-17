using UnityEngine;

public class JumpToLastScript : MonoBehaviour
{
    public GameObject targetObject;

    public void ExecuteLastScriptAction()
    {
        CutsceneElementBase[] scripts = targetObject.GetComponents<CutsceneElementBase>();

        if (scripts.Length > 0)
        {
            CutsceneElementBase lastScript = scripts[scripts.Length - 1];
            
            Debug.Log("The last script is: " + lastScript.GetType().Name);
            lastScript.Execute();
        }
    }
}