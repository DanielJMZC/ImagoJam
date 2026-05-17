using UnityEngine;
using System.Collections;

public class CSE_AnimationStart : CutsceneElementBase
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    [SerializeField] private GameObject objectToEnable; 
    [SerializeField] private float waitDuration = 1f;
    [SerializeField] private bool disableObjectWhenDone = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Execute()
    {
        StartCoroutine(PlayAnimationRoutine());
    }


    private IEnumerator PlayAnimationRoutine()
    {
       
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
        yield return null;

        if (animator != null)
        {
            animator.Play(animationName);
        }

        if (waitDuration > 0)
        {
            yield return new WaitForSeconds(waitDuration);
        }

        if (disableObjectWhenDone && objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }
        
        if (cutsceneHandler != null)
        {
            cutsceneHandler.PlayNextElement();
        }
    }
}
