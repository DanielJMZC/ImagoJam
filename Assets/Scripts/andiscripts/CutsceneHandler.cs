using UnityEngine;

public class CutsceneHandler : MonoBehaviour
{
    public Camera cam;
    private CutsceneElementBase[] cutsceneElements;
    private int index = -1;
    [SerializeField] private bool playOnStart = false;
    public void Start()
    {
        cutsceneElements = GetComponents<CutsceneElementBase>();
        if (playOnStart)
        {
            PlayNextElement();
        }
    }
    private void ExecuteCurrentElement()
    {
        if (index >= 0 && index <cutsceneElements.Length)
        {
            cutsceneElements[index].Execute();
        }

    }
    public void PlayNextElement()
    {
        index++;
        ExecuteCurrentElement();
    }
}
