using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    private List<string> dialogues = new List<string>(); // Inicializar con una lista vacía

    private int currentDialogueIndex = 0;

    public string GetCurrentDialogue()
    {
        if (dialogues.Count == 0)
        {
            return null; // Devuelve null si no hay diálogos
        }

        return dialogues[currentDialogueIndex];
    }

    public void NextDialogue()
    {
        if (dialogues.Count == 0)
        {
            return;
        }

        currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Count;
        if (currentDialogueIndex == 0) // Opcional: Solo vuelve al inicio si hay más diálogos
        {
            // No hacer nada si queremos que se oculte después del último diálogo
        }
    }

    public void AddDialogue(string newDialogue)
    {
        if (!string.IsNullOrEmpty(newDialogue))
        {
            dialogues.Add(newDialogue);
        }
    }

    public void RemoveDialogue(int index)
    {
        if (index >= 0 && index < dialogues.Count)
        {
            dialogues.RemoveAt(index);
        }
    }
}
