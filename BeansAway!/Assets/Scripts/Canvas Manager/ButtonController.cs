using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    SwitchCanvas,
    QuitGame
}

public class ButtonController : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    public ButtonType buttonType;
    private CanvasManager canvasManager;
    private Button UIButton;

    public delegate void Action();
    public Action onClickAction { set; get; }

// Start is called before the first frame update
    void Start()
    {
        UIButton = GetComponent<Button>();
        UIButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();

        switch (buttonType) //Assign button action via delegates
        {
            case ButtonType.SwitchCanvas:
                onClickAction = SwitchCanvasAction;
                break;
            case ButtonType.QuitGame:
                onClickAction = QuitGameAction;
                break;
            default:
                break;
        }
    }

    private void OnButtonClicked()
    {
        onClickAction();
    }

    private void SwitchCanvasAction()
    {
        canvasManager.SwitchCanvas(desiredCanvasType);
    }

    private void QuitGameAction()
    {
        // Save any game data here to some file

        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
