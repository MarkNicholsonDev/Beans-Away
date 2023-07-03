using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType { 
    MainMenu,
    GameUI,
    EndScreen
}
public class CanvasManager : Singleton<CanvasManager>
{
    private List<CanvasController> canvasControllerList;
    private CanvasController lastActiveCanvas;
    protected override void Awake()
    {
        base.Awake();

        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();

        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType newCanvas)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        else { Debug.LogWarning("The last active canvas wasn't found!"); }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == newCanvas);
        if (desiredCanvas)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas wasn't found!"); }
    }
}
