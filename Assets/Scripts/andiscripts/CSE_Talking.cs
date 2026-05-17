using UnityEngine;
using TMPro;

public class CSE_Talking : CutsceneElementBase
{
    [SerializeField] private TMP_Text popUpText;
    [SerializeField] private TMP_Text popUpText2;
    [TextArea]
    [SerializeField] private string dialogue;
    [SerializeField] private string charaName;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private GameObject objectToEnable2;
    [SerializeField] private float fadeOutWaitTime = 0.3f;
    private bool isTriggered = false;

    public override void Execute()
    {
        StartCoroutine(TalkRoutine());
    }

    private System.Collections.IEnumerator TalkRoutine()
    {
        if (objectToEnable != null) objectToEnable.SetActive(true);
        if (objectToEnable2 != null) objectToEnable2.SetActive(true);
        
        if (popUpText != null) popUpText.gameObject.SetActive(true);
        if (popUpText2 != null) popUpText2.gameObject.SetActive(true);

        if (popUpText != null)
        {
            popUpText.text = dialogue;
            popUpText.ForceMeshUpdate();
        }
        
        if (popUpText2 != null)
        {
            popUpText2.text = charaName;
            popUpText2.ForceMeshUpdate();
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
            StartCoroutine(FinishDialogueRoutine());
        }
    }

    private System.Collections.IEnumerator FinishDialogueRoutine()
    {
        if (anim != null) anim.Play("FadeOut");
        
        yield return new WaitForSeconds(fadeOutWaitTime);

        if (objectToEnable != null) objectToEnable.SetActive(false);
        if (objectToEnable2 != null) objectToEnable2.SetActive(false);
        if (popUpText != null) popUpText.gameObject.SetActive(false);
        if (popUpText2 != null) popUpText2.gameObject.SetActive(false);
        
        if (cutsceneHandler != null)
        {
            cutsceneHandler.PlayNextElement();
        }
    }
}
