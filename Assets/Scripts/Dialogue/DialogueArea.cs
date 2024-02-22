using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogueSO;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.PUTTDialogueSubscriber(dialogueSO);
            EventManager.Instance.DialogueUIOpen();
            Destroy(this.gameObject);
        }
    }
}
