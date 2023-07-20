using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using System.Linq;

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

    //Camera management
    [SerializeField] private List<CinemachineVirtualCameraBase> cameraList;
    private CinemachineVirtualCameraBase activeCamera;

    //Scene management
    [SerializeField] private List<GameObject> sceneObjects;
    private GameObject activeScene;

    protected override void Awake()
    {
        base.Awake();

        foreach (CinemachineVirtualCameraBase cam in cameraList) {
            cam.Priority = 0;
        }
        
        foreach (GameObject scene in sceneObjects) {
           scene.SetActive(false);
        }

        //Initialise main menu
        activeCamera = cameraList.ElementAt(0);
        activeScene = sceneObjects.ElementAt(0);
        activeScene.SetActive(true);

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
                //On switch:
                activeCamera.Priority = 0;
                activeCamera = cameraList.ElementAt(0);
                activeCamera.Priority = 10;
                
                activeScene.SetActive(false);
                activeScene = sceneObjects.ElementAt(0);
                activeScene.SetActive(true);
                break;
            case GameState.InGame:
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                //On switch:
                activeCamera.Priority = 0;
                activeCamera = cameraList.ElementAt(1);
                activeCamera.Priority = 10;

                activeScene.SetActive(false);
                activeScene = sceneObjects.ElementAt(1);
                activeScene.SetActive(true);
                break;
            case GameState.EndScreen:
                canvasManager.SwitchCanvas(CanvasType.EndScreen);
                //On switch:
                activeCamera.Priority = 0;
                activeCamera = cameraList.ElementAt(0);
                activeCamera.Priority = 10;

                activeScene.SetActive(false);
                activeScene = sceneObjects.ElementAt(0);
                activeScene.SetActive(true);
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
