using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;
    private int checkpointPos; //Index of the checkpoint in the gamemanager list

    public Material nextMat;
    public Material nextNextMat;
    void Awake()
    {
        gameObject.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null) { Debug.LogWarning("Game Manager not found"); }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Plane")) {
            gameManager.CheckpointCheck(checkpointPos);
        }
    }

    public void SetCheckpointPos(int checkpointPosition) {
        checkpointPos = checkpointPosition;
    }

    public void ChangeMaterial(int matInt) {
        if (matInt == 0)
        {
            this.GetComponent<Renderer>().material = nextMat;
        }
        else {
            this.GetComponent<Renderer>().material = nextNextMat;
        }
    }
}
