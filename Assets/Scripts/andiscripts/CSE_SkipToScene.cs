using UnityEngine;
using UnityEngine.SceneManagement;

public class CSE_SkipToScene : CutsceneElementBase
{
    [SerializeField] private string nextSceneName;

    public override void Execute()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}