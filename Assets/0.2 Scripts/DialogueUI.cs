using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa la biblioteca de TextMeshPro

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel; // Panel de diálogo
    [SerializeField] private TextMeshProUGUI dialogueText; // Texto del diálogo

    private void Start()
    {
        // Asegúrate de que el panel esté inicialmente oculto
        dialoguePanel.SetActive(false);
    }

    // Método para mostrar el diálogo
    public void ShowDialogue(string message)
    {
        dialogueText.text = message;
        dialoguePanel.SetActive(true);
    }

    // Método para ocultar el diálogo
    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}