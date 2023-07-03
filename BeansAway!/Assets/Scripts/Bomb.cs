using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private bool isArmed = false;
    public BomberController player;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;
    [SerializeField] private GameObject particles;
    private Rigidbody rb;
    private CapsuleCollider cc;

    private void Awake() {
        isArmed = false;
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
    }

    public void ArmBomb() {
        isArmed= true;
        rb.isKinematic = false;
        cc.enabled = true;
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (isArmed == true) {
            var surroundingObjects = Physics.OverlapSphere(transform.position, explosionRadius);
            
            foreach (var obj in surroundingObjects)
            {
                var rb = obj.GetComponent<Rigidbody>();
                if (rb != null) 
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
            player.IncrementScore(surroundingObjects.Length);

            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
