using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private NPCDialogue npcDialogue; // Referencia al componente NPCDialogue
    [SerializeField] private DialogueUI dialogueUI; // Referencia al componente DialogueUI
    [SerializeField] private float interactionDistance = 2f;

    private Transform playerTransform;
    private bool isDialogueActive = false; // Para verificar si el diálogo está activo
    public GameObject canvaspresionz;

    private void Start()
    {
        // Encuentra el transform del jugador (asegúrate de que el objeto "Player" esté etiquetado correctamente)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Verifica la distancia entre el jugador y el NPC
        if (Vector3.Distance(playerTransform.position, transform.position) <= interactionDistance)
        {
            canvaspresionz.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                
                if (isDialogueActive)
                {
                    // Ocultar el diálogo si ya está activo
                    dialogueUI.HideDialogue();
                    isDialogueActive = false;
                }
                else
                {
                    // Verificar si hay más diálogos para mostrar
                    if (npcDialogue.GetCurrentDialogue() != null)
                    {
                        // Muestra el diálogo actual en la UI
                        dialogueUI.ShowDialogue(npcDialogue.GetCurrentDialogue());
                        npcDialogue.NextDialogue();
                        isDialogueActive = true;
                    }
                }
            }
        }
        else if (isDialogueActive)
        {
            // Ocultar el diálogo si el jugador se aleja del NPC            
            dialogueUI.HideDialogue();
            isDialogueActive = false;
        }
        else
        {
            canvaspresionz.SetActive(false);
        }
        
    }
}