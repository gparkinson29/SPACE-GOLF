using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //instance of the event manager singleton
    public static EventManager Instance { get; private set; }

    //actions
    //private Action<Dialogue> OnPUTTDialogue;
    private Action<LevelController.gameState> OnStateChange { get; }

    //events
    [SerializeField]
    private UnityEvent<Dialogue> OnPUTTDialogueChange;
    [SerializeField]
    private UnityEvent OnDialogueUIUpdate, OnDialogueUIOpen, OnDialogueUIClose, OnAudioPause, OnAudioResume;

    //action subscribing functions
    public void PUTTDialogueSubscriber(Dialogue newDialogue)
    {
        OnPUTTDialogueChange?.Invoke(newDialogue);
    }

    public void StateChangeSubscriber(LevelController.gameState newState)
    {
        OnStateChange?.Invoke(newState);
    }

    public void DialogueUIUpdate()
    {
        OnDialogueUIUpdate?.Invoke();
    }

    public void DialogueUIOpen()
    {
        OnDialogueUIOpen?.Invoke();
    }

    public void DialogueUIClose()
    {
        OnDialogueUIClose?.Invoke();
    }

    public void PauseAudioPlayback()
    {
        OnAudioPause?.Invoke();
    }

    public void ResumeAudioPlayback()
    {
        OnAudioResume?.Invoke();
    }

    //getting the private Actions 
    //public Action<Dialogue> GetPUTTDialogueAction()
    //{
    //return OnPUTTDialogue;
    //}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
