using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Interaction : MonoBehaviour
{
    [SerializeField] private NPCDialogue npcDialogue; // Referencia al componente NPCDialogue
    [SerializeField] private DialogueUI dialogueUI; // Referencia al componente DialogueUI
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private float initialDialogueDelay = 3f; // Retraso para el primer diálogo

    private Transform playerTransform;
    private bool isDialogueActive = false;
    private bool hasShownInitialDialogue = false; // Para saber si el primer diálogo ya se mostró

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Iniciar la coroutine para mostrar el primer diálogo después de un retraso
        StartCoroutine(ShowInitialDialogueAfterDelay());
    }

    private IEnumerator ShowInitialDialogueAfterDelay()
    {
        yield return new WaitForSeconds(initialDialogueDelay);

        // Mostrar el primer diálogo automáticamente después del retraso
        if (npcDialogue.GetCurrentDialogue() != null)
        {
            dialogueUI.ShowDialogue(npcDialogue.GetCurrentDialogue());
            isDialogueActive = true; // El diálogo está activo
            hasShownInitialDialogue = true; // Marcamos que el primer diálogo se mostró
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (isDialogueActive)
                {
                    // Ocultar el diálogo si el primer diálogo ya se mostró
                    if (hasShownInitialDialogue)
                    {
                        dialogueUI.HideDialogue();
                        isDialogueActive = false;
                    }
                }
                else
                {
                    // Mostrar el siguiente diálogo si hay más
                    if (npcDialogue.GetCurrentDialogue() != null)
                    {
                        dialogueUI.ShowDialogue(npcDialogue.GetCurrentDialogue());
                        npcDialogue.NextDialogue();
                        isDialogueActive = true;
                    }
                }
            }
        }
        else if (isDialogueActive)
        {
            // Ocultar el diálogo si el jugador se aleja
            dialogueUI.HideDialogue();
            isDialogueActive = false;
        }
    }
}