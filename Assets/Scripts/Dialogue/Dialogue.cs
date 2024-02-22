using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private List<string> dialogueLines;


    public List<string> GetAllDialogueLines()
    {
        return dialogueLines;
    }
}
