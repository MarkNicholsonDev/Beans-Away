using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public enum GameState
{
    MainMenu,
    InGame,
    EndScreen
}

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    private CanvasManager canvasManager;
    private GameState currentState;
    private List<CinemachineVirtualCamera> cameraList;

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start() {
        canvasManager = FindObjectOfType<CanvasManager>();
        if (canvasManager == null) { Debug.LogWarning("Canvas Manager not found"); }
    }

    public void ChangeGamestate(GameState desiredState)
    {
        currentState = desiredState;

        switch (currentState) {
            case GameState.MainMenu:
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                
                break;
            case GameState.InGame:
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                
                break;
            case GameState.EndScreen:
                canvasManager.SwitchCanvas(CanvasType.EndScreen);
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(desiredState), desiredState, null);
        }
        //Notify any scripts here that game logic has changed possibly via an event but unsure whether to use
        //Then let know anyone who subscribed to the action about it via .Invoke()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
