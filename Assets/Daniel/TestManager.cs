using UnityEngine;
using System.Collections.Generic;

public class TestManager : MonoBehaviour
{
    [Header("NPCs in Scene")]
    public List<NPCDialogueManager> npcDialogueManagers = new List<NPCDialogueManager>();

    [Header("Interaction Settings")]
    public float interactionDistance = 2f;
    public KeyCode interactionKey = KeyCode.E;

    [Header("Visual Feedback")]
    public GameObject interactionPrompt;

    private Transform player;
    private bool playerInRange = false;

    private int day = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    private void Update()
    {
        if (player == null) return;

        playerInRange = Vector3.Distance(transform.position, player.position) <= interactionDistance;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(playerInRange);

        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            AdvanceDay();
        }
    }

    private void AdvanceDay()
    {
        day++;
        Debug.Log("DAY " + day + " STARTED");
        Debug.Log("NPC count: " + npcDialogueManagers.Count);
        foreach (var npc in npcDialogueManagers)
        {
            
            if (npc != null)
            {
                npc.AssignBestConversation();
            }
        }
    }
}