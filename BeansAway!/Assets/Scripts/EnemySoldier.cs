using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;
using static BaseBehaviour;

public class EnemySoldier : MonoBehaviour
{
    //Unit formation variables
    [SerializeField]
    private BaseBehaviour behaviour;
    public GameObject parentUnit { set; get; }
    public int childIndex;
    public List<GameObject> neighbours { set; get; }
    public Vector3 desiredPos { set; get; }
    public Vector3 endPos { set; get; }
    public Vector3 formationOffset { set; get; }

    private Rigidbody rb;
    [SerializeField]
    private float maxMovementSpeed;
    private float maxAccel;
    private float maxForce;
    private float velocityGain;
    private float maxRot;

    [SerializeField]
    public bool usePathfinding;
    private NavMeshAgent navAgent;

    private float orientation;
    private float rotation;
    public float halfHeight { set; get; }
    private Vector3 velocity;
    private Vector3 displacement;


    [SerializeField]
    private float desiredSeperation;
    Vector3 repulsionVec = Vector3.zero;
    [SerializeField]
    public float repulsionWeight;
    Vector3 neighbourVec = Vector3.zero;
    [SerializeField]
    public float cohesionWeight;
    private float perceptionRange;

    public delegate void Movement();
    public Movement movementState { set; get; }

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementState = Idle;

        if (usePathfinding)
        {
            navAgent = GetComponent<NavMeshAgent>();
            navAgent.destination = desiredPos;
        }

        maxMovementSpeed = 10.0f;
        maxAccel = 2.5f;
        maxForce = 40.0f;
        velocityGain = 5.0f;
    }

    // Update is called once per frame
    public void Update()
    {
        desiredPos = parentUnit.transform.position + formationOffset + new Vector3(0, halfHeight - 0.08f, 0); //Default desiredPos is formation - can be overridden
        if (usePathfinding) { navAgent.destination = parentUnit.transform.position + formationOffset + new Vector3(0, halfHeight - 0.08f, 0); }
        BoidSeperation();
        BoidCohesion();
        movementState();
    }

    public void FixedUpdate()
    { //Application of movement forces to Rigidbody here
        if (usePathfinding) { return; }
        Vector3 dist = velocity;
        dist.y = 0;
        Vector3 targetVel = Vector3.ClampMagnitude(maxAccel * dist, maxMovementSpeed);
        Vector3 velocityError = targetVel - rb.velocity;
        Vector3 force = Vector3.ClampMagnitude(velocityGain * velocityError, maxForce);
        rb.AddForce(force);
        //A concern about this method is that it doesn't take into account the mass of the unit/boid so units of varying masses
        //would move the same when they shouldn't e.g cavalry or heavy units should have a brake force applied close to the target - but it works well
        //(This would be to model the momentum of the unit due to mass of armour etc.)
        if (velocity.magnitude > maxMovementSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxMovementSpeed;
        }
        if (velocity.magnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }
        velocity = Vector3.zero;
    }

    private void BoidCohesion()
    {
        if (usePathfinding) { return; }
        float dist = (desiredPos - transform.position).magnitude;

        if ((desiredPos - transform.position).magnitude >= 0.1f)
        {
            Vector3 diff = desiredPos - transform.position;
            diff /= dist;
            velocity += diff * cohesionWeight;
        }
    }
    private void BoidSeperation()
    {
        int count = 0;
        repulsionVec = Vector3.zero;

        foreach (GameObject neighbour in neighbours)
        {
            if (neighbour != null)
            { // Checks if the neighbour exists - Could have died
                float dist = (transform.position - neighbour.transform.position).magnitude;

                if ((dist > 0) && (dist < desiredSeperation))
                {
                    Vector3 diff = (transform.position - neighbour.transform.position).normalized;
                    diff /= dist;
                    repulsionVec += diff;
                    count++;
                }
            }
        }
        if (count > 0)
        {
            repulsionVec /= (float)count;
        }
        velocity += repulsionVec * repulsionWeight;
    }

    public void Idle() {
    }
    public void MoveTo() {
        if ((endPos - transform.position).magnitude <= 0.1f) { //Account for floating point inaccuracy in movement
            behaviour.state = BoidFSM.Idle;
        }
    }

    public void Attack()
    {
        //Left here for representing when two units are engaged with one another in melee
    }
}
