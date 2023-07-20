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
    [SerializeField] private GameObject player;

    //Tutorial flight mission management
    private int currentCheckpoint = 0; //Indexs into the positions below
    [SerializeField] private List<GameObject> checkpointPositions;

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

    public void CheckpointCheck(int checkpointIndex)
    {
        if (checkpointIndex == currentCheckpoint)
        {
            if ((checkpointIndex + 2) > checkpointPositions.Count)
            { //Checks if the last checkpoint has been reached
                ChangeGamestate(GameState.EndScreen);
            }
            else if ((checkpointIndex + 2) == checkpointPositions.Count) { //Second to last checkpoint check
                GameObject currentPoint = checkpointPositions.ElementAt(checkpointIndex);
                currentPoint.SetActive(false);
                GameObject nextPoint = checkpointPositions.ElementAt(checkpointIndex + 1);
                nextPoint.GetComponent<Checkpoint>().ChangeMaterial(0);

                currentCheckpoint++;
            }
            else { //Continue with standard checkpoint adjustments
                GameObject currentPoint = checkpointPositions.ElementAt(checkpointIndex);
                currentPoint.SetActive(false);
                GameObject nextPoint = checkpointPositions.ElementAt(checkpointIndex + 1);
                nextPoint.GetComponent<Checkpoint>().ChangeMaterial(0);
                GameObject nextNextPoint = checkpointPositions.ElementAt(checkpointIndex + 2);
                nextNextPoint.GetComponent<Checkpoint>().ChangeMaterial(1);
                nextNextPoint.SetActive(true);

                currentCheckpoint++;
            }
        }
    }

    private void CheckpointInitialise() {
        //Initialising first two checkpoints
        GameObject currentPoint = checkpointPositions.ElementAt(currentCheckpoint);
        currentPoint.SetActive(true);
        currentPoint.GetComponent<Checkpoint>().ChangeMaterial(0);
        GameObject nextPoint = checkpointPositions.ElementAt(currentCheckpoint + 1);
        nextPoint.SetActive(true);
        nextPoint.GetComponent<Checkpoint>().ChangeMaterial(1);

        //Setting up checkpoint ordering
        int index = 0;
        foreach (GameObject checkpoint in checkpointPositions) {
            checkpoint.GetComponent<Checkpoint>().SetCheckpointPos(index);
            index++;
        }
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

                BomberController controller = player.GetComponent<BomberController>();
                player.transform.position = controller.startPos;
                controller.ResetBomber();
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

                currentCheckpoint = 0;
                CheckpointInitialise();
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
    void Update() {
        //Checkpoint Management if in gamestate here

    }
}
