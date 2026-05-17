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

    private bool isTriggered = false;

    public override void Execute()
    {
        StartCoroutine(TalkRoutine());
    }

    private System.Collections.IEnumerator TalkRoutine()
    {
        if (objectToEnable != null) objectToEnable.SetActive(true);
        if (popUpText != null && popUpText2 != null)  {
            popUpText.gameObject.SetActive(true);
            popUpText2.gameObject.SetActive(true);
        }

        if (popUpText != null && popUpText2 != null)
        {
            popUpText.text = dialogue;
            popUpText.ForceMeshUpdate();
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

            if (anim != null) anim.Play("FadeOut");
            
            if (objectToEnable != null && popUpText != null && popUpText2 != null)
            {
                objectToEnable.SetActive(false);
                popUpText.gameObject.SetActive(false);
                popUpText2.gameObject.SetActive(false);
            }
            
            if (cutsceneHandler != null)
            {
                cutsceneHandler.PlayNextElement();
            }
        }
    }
}

