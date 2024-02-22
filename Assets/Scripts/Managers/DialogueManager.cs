using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogueSO;
    private Queue<string> linesInCurrentDialogue = new Queue<string>();
    private string currentLine;

    private void Awake()
    {
        
    }

    public void StartWriting()
    {
        foreach (string line in dialogueSO.GetAllDialogueLines())
        {
            linesInCurrentDialogue.Enqueue(line);
        }
        currentLine = linesInCurrentDialogue.Peek();
        UpdateLine();
    }

    public void UpdateLine()
    {
        if (linesInCurrentDialogue.Count == 0)
        {
            StopWriting();
        }
        else
        {
            currentLine = linesInCurrentDialogue.Dequeue();
            EventManager.Instance.DialogueUIUpdate();
        }
    }

    public void StopWriting()
    {
        linesInCurrentDialogue.Clear();
        EventManager.Instance.DialogueUIClose();
    }

    public void DialogueChanged(Dialogue newDialogue)
    {
        dialogueSO = newDialogue;
        linesInCurrentDialogue.Clear();

    }

    public string GetCurrentLine()
    {
        return currentLine;
    }
}
