using UnityEngine;
using TMPro;

public class CSE_PopUpDialogue : CutsceneElementBase
{
    [SerializeField] private TMP_Text popUpText;
    [TextArea]
    [SerializeField] private string dialogue;
    [SerializeField] private Animator anim;

    private bool isTriggered = false;

    public override void Execute()
    {
        StartCoroutine(TalkRoutine());
    }

    private System.Collections.IEnumerator TalkRoutine()
    {
        if (popUpText != null )  {
            popUpText.gameObject.SetActive(true);
        }

        if (popUpText != null )
        {
            popUpText.text = dialogue;
            popUpText.ForceMeshUpdate();
        }

        yield return null;

        if (anim != null) anim.Play("FadeIn");
        isTriggered = true;
    }

    public override void Update()
    {
        base.Update();
        if (!isTriggered) return;

        if (Input.GetButtonDown("Interact"))
        {
            isTriggered = false; 

            if (anim != null) anim.Play("FadeOut");
            
            if ( popUpText != null)
            {
                popUpText.gameObject.SetActive(false);
            }
            
            if (cutsceneHandler != null)
            {
                cutsceneHandler.PlayNextElement();
            }
        }
    }
}

