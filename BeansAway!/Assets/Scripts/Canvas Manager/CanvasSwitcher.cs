using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    private CanvasManager canvasManager;
    private Button UIButton;

    // Start is called before the first frame update
    void Start()
    {
        UIButton = GetComponent<Button>();
        UIButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    private void OnButtonClicked()
    { 
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
