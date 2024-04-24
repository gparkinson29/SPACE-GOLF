using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private TextMeshProUGUI currentLineText;
    private int numCharsCurrentLine;

    public void UpdateUI()
    {
        currentLineText.text = dialogueManager.GetCurrentLine();
        StopAllCoroutines();
        StartCoroutine(WriteCurrentLineToScreen());
    }

    IEnumerator WriteCurrentLineToScreen()
    {
        currentLineText.text = string.Empty;
        numCharsCurrentLine = dialogueManager.GetCurrentLine().ToCharArray().Length;
        foreach(char c in dialogueManager.GetCurrentLine().ToCharArray())
        {
            currentLineText.text += c;
            yield return new WaitForSeconds(0.08f);
            //StartCoroutine(DelayToNextLine());
        }
        StartCoroutine(DelayToNextLine());
    }

    IEnumerator DelayToNextLine()
    {
        yield return new WaitForSeconds(2f); //needs to be altered to go after the dialogue finished but this will work for now
        dialogueManager.UpdateLine();
    }
}
