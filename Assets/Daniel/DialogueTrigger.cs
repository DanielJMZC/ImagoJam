using UnityEngine;

public class Dialoguetrigger : MonoBehaviour
{
    public DialogueConversation dialogue;

    [Header("Interaction Settings")]
    public bool requiresPlayerNearby = true;
    public float interactionDistance = 2f;
    public KeyCode interactionKey = KeyCode.E;

    [Header ("Visual Feedback")]
    public GameObject interactionPrompt;

    private Transform player;
    private bool playerInRange = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        playerInRange = distance <= interactionDistance;

        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(playerInRange && !DialogueManager.Instance.IsInDialogue());
        }

        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        if (dialogue != null && DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartConversation(dialogue);
        }
    }

   
}