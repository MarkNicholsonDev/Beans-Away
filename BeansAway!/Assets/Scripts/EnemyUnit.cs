using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static BaseBehaviour;
using static UnityEngine.GraphicsBuffer;
using System;
using System.Diagnostics;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private GameObject childPrefab;
    private Rigidbody rb;
    private SphereCollider unitCollider;
    private Vector3 center;
    private float radius;

    [SerializeField]
    private const int maxUnitSize = 20;
    private const int minUnitWidth = 3;

    private List<GameObject> children = new List<GameObject>();

    //Unit Management variables
    private bool changeState;
    public UnitFSM currentUnitState { set; get; }
    public enum UnitFSM
    {
        Attack,
        Moving,
        Idle
    }
    public float unitHalfHeight { set; get; }

    [Range(5.0f, maxUnitSize)]
    public int unitWidth;
    private int unitDepth;

    public int columnNum { private set; get; }
    private NavMeshAgent navAgent;
    public int collisionNum { set; get; }

    public Vector3 desiredPos { set; private get; }

    // Start is called before the first frame update
    void Start()
    {
        changeState = false;
        currentUnitState = UnitFSM.Idle;
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        unitCollider = GetComponent<SphereCollider>();
        navAgent.autoBraking = true;
        unitHalfHeight = 0.5f;
        columnNum = unitWidth;
        collisionNum = 0;

        if (maxUnitSize < columnNum)
        { //Default max soldier's per row is 10, if unit size is less set it
            columnNum = maxUnitSize;
        }

        for (int i = 0; i < maxUnitSize; i++)
        {
            Vector3 relativeSpawn = new Vector3(i % columnNum, 0.33f, -i / columnNum) * 1.5f;
            GameObject temp = Instantiate(childPrefab, transform.position + relativeSpawn, transform.rotation);
            EnemySoldier boid = temp.GetComponent<EnemySoldier>();
            boid.formationOffset = new Vector3(relativeSpawn.x, 0.0f, relativeSpawn.z);
            boid.endPos = temp.transform.position - new Vector3(0, 0.66f, 0);
            boid.halfHeight = unitHalfHeight;
            boid.childIndex = i;
            boid.parentUnit = this.gameObject;
            children.Add(temp);
        }

        foreach (GameObject child in children) {
            child.GetComponent<EnemySoldier>().neighbours = children;
        }

        MoveToPosition(targetObj.transform.position);
    }

    public void MoveToPosition(Vector3 position)
    {
        changeState = true;
        desiredPos = position;
        navAgent.destination = desiredPos;
        currentUnitState = UnitFSM.Moving;
        EnemySoldier boid;
        bool hitBool = false;
        RaycastHit hit;
        int newUnitWidth = columnNum; //Required unit size to pass through
        foreach (GameObject child in children)
        {
            boid = child.GetComponent<EnemySoldier>();
            boid.endPos = desiredPos + boid.formationOffset + new Vector3(0, unitHalfHeight, 0);
        }

        desiredPos = position + new Vector3(0, 0.08f, 0); //+0.08 to account for the raised nav mesh which the unit moves on
    }

    void ReformFormation()
    {
        int i = 0;
        if (columnNum < minUnitWidth) { columnNum = minUnitWidth; } //Sanity check to minimum unit width
        foreach (GameObject child in children)
        {
            Vector3 relativeSpawn = new Vector3(i % columnNum, 0.33f, -i / columnNum) * 1.5f;
            child.GetComponent<EnemySoldier>().formationOffset = new Vector3(relativeSpawn.x, 0.0f, relativeSpawn.z);
            i++;
        }
    }

    void Update()
    {
        //Update info for debug Gizmos
        //Stopwatch st = new Stopwatch();
        //st.Start();
        float tempFloat = (float)maxUnitSize / (float)columnNum;
        unitDepth = (int)Math.Ceiling(tempFloat);
        float widthOffset = (float)columnNum - 1;

        if (changeState)
        { //On entering new Unit state
            if (currentUnitState == UnitFSM.Moving)
            {
                Vector3 relative = Vector3.zero;
                int i = 0;
                foreach (GameObject child in children)
                {
                    child.GetComponent<BaseBehaviour>().state = BoidFSM.Moving;
                    i++;
                }
                changeState = false;
            }
            if (currentUnitState == UnitFSM.Attack)
            {
                //On enter behaviour here
                changeState = false;
            }
            if (currentUnitState == UnitFSM.Idle)
            {
                //On enter behaviour here
                changeState = false;
            }
        }
        else
        { //Unit state behaviour
            if (unitWidth != columnNum)
            { //Check if unit formation needs changing prior to state behaviour
                if (unitWidth <= maxUnitSize / 2)
                {
                    columnNum = unitWidth;
                    ReformFormation();
                }
            }
            if (currentUnitState == UnitFSM.Moving)
            {
                //Navigation handling
                if ((desiredPos - transform.position).magnitude <= 0.01f)
                { //Account for floating point inaccuracy in movement
                    currentUnitState = UnitFSM.Idle;
                }
            }
            if (currentUnitState == UnitFSM.Attack)
            {
                //Attack with the unit
            }
            if (currentUnitState == UnitFSM.Idle)
            {
                //Idle with the unit
            }
        }
        //st.Stop();
        //UnityEngine.Debug.Log(string.Format("MyMethod took {0} ms to complete", st.ElapsedMilliseconds));
    }

    //Handling Gate detection via Triggers
    private void OnTriggerEnter(Collider other) {
        //Lose Condition here for enemy
        if (other.gameObject.name == "Flag Objective") {
            Application.Quit();
        }
    }
}
