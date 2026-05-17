using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject dialoguePanel;
    public CanvasGroup dialogueCanvasGroup;

    [Header("Speaker Display")]
    public TextMeshProUGUI speakerNameText;
    public Image speakerPortraitImage;

    [Header("Dialogue Display")]
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    [Header("Continuation")]
    public GameObject continueButton;

    [Header("Choices")]
    public GameObject choiceButtonContainer;
    public GameObject choiceButtonPrefab;
    private List<GameObject> activeChoiceButtons = new List<GameObject>();

    [Header("Audio")]
    public AudioSource voiceAudioSource;
    public AudioSource uiAudioSource;
    public AudioClip buttonClickSound;

    [Header("Animation")]
    public float fadeSpeed = 2f;
    private void Awake()
    {
        if (dialogueCanvasGroup == null)
        {
            dialogueCanvasGroup = dialoguePanel.AddComponent<CanvasGroup>();
        }
        Hide();
    }
    public void Show()
    {
        dialoguePanel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }


    public void Hide()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        dialogueCanvasGroup.alpha = 0f;
        while (dialogueCanvasGroup.alpha < 1f)
        {
            dialogueCanvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (dialogueCanvasGroup.alpha > 0f)
        {
            dialogueCanvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        dialoguePanel.SetActive(false);
    }

    public void SetSpeakerName(string name)
    {
        speakerNameText.text = name;
    }

    public void SetSpeakerPortrait(Sprite portrait)
    {
        if (portrait != null)
        {
            speakerPortraitImage.sprite = portrait;
            speakerPortraitImage.gameObject.SetActive(true);
        }
        else
        {
            speakerPortraitImage.gameObject.SetActive(false);
        }
    }

    public void SetDialogueText(string text)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(text));
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "                      ";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
    }

     public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            // Show full text immediately
        }
    }

    public void ShowContinueButton()
    {
        HideChoices();
        continueButton.SetActive(true);
    }

    public void ShowChoices(List<DialogueResponse> responses)
    {
        continueButton.SetActive(false);
        HideChoices();

        List<DialogueResponse> availableResponses = new List<DialogueResponse>();
        foreach (var response in responses)
        {
            if (response.MeetsConditions())
            {
                availableResponses.Add(response);
            }
        }

        // Create choice buttons
        for (int i = 0; i < availableResponses.Count; i++)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonContainer.transform);
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = availableResponses[i].responseText;

            int responseIndex = responses.IndexOf(availableResponses[i]);
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => OnChoiceSelected(responseIndex));

            activeChoiceButtons.Add(buttonObj);
        }

        choiceButtonContainer.SetActive(true);
    }

    private void HideChoices()
    {
        foreach (var button in activeChoiceButtons)
        {
            Destroy(button);
        }
        activeChoiceButtons.Clear();
        choiceButtonContainer.SetActive(false);
    }

    private void OnChoiceSelected(int index)
    {
        PlayButtonSound();
        DialogueManager.Instance.SelectResponse(index);
    }

    public void OnContinueClicked()
    {
        PlayButtonSound();

        if (typingCoroutine != null)
        {
            SkipTyping();
        }
        else
        {
            DialogueManager.Instance.ContinueDialogue();
        }
    }

    public void SetupConversationEnd()
    {
        TextMeshProUGUI continueText = continueButton.GetComponentInChildren<TextMeshProUGUI>();
        if (continueText != null)
        {
            continueText.text = "End Conversation";
        }
    }

    public void PlayVoiceClip(AudioClip clip)
    {
        if (voiceAudioSource != null && clip != null)
        {
            voiceAudioSource.clip = clip;
            voiceAudioSource.Play();
        }
    }

    private void PlayButtonSound()
    {
        if (uiAudioSource != null && buttonClickSound != null)
        {
            uiAudioSource.PlayOneShot(buttonClickSound);
        }
    }


}