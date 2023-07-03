using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class BomberController : MonoBehaviour {
    //Movement handling
    private float maxThrust = 200f;
    private float throttleAccel = 0.1f;
    private float bomberResponsiveness = 10f;
    private float throttle;
    private float pitch;
    private float roll;
    private float yaw;
    private float liftForce = 135f;

    private BomberInput bomberInput = null;
    private Vector2 movementVector = Vector2.zero;
    private float movementYaw = 0.0f;
    private float throttleInp = 0.0f;

    private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI hud;
    [SerializeField] private Transform propeller;
    AudioSource engineSound;
    private int score = 0;

    //Weapon handling
    [SerializeField] private Transform[] bombPositions = new Transform[2];
    [SerializeField] private GameObject bombPrefab;
    private float bombRelease;
    private int bombNum = 2;
    private bool bombReloading;
    private float bombReloadTime = 2.0f;
    private float fireGuns;
    private float gunsAmmo;

    public bool menuBomber;

    private float propVolume = 0.01f;
    
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        bomberInput = new BomberInput();
        if (menuBomber) { throttle = 100f; maxThrust = 0.001f; }
    }
    // Start is called before the first frame update
    void Start() {
        bomberInput.Enable();
        engineSound = GetComponent<AudioSource>();
        StartCoroutine(ReloadBombs());
    }

    private void OnEnable() {
        bomberInput.Enable();
        bomberInput.Player.Movement.performed += OnMovementPerformed;
        bomberInput.Player.Movement.canceled += OnMovementCancelled;
        bomberInput.Player.YawControl.performed += OnYawPerformed;
        bomberInput.Player.YawControl.canceled += OnYawCancelled;
        bomberInput.Player.ThrottleControl.performed += OnThrottlePerformed;
        bomberInput.Player.ThrottleControl.canceled += OnThrottleCancelled;
        bomberInput.Player.BombRelease.performed += OnBombDropPerformed;
        bomberInput.Player.BombRelease.canceled += OnBombDropCancelled;
    }

    private void OnDisable() { 
        bomberInput.Disable();
        bomberInput.Player.Movement.performed -= OnMovementPerformed;
        bomberInput.Player.Movement.canceled -= OnMovementCancelled;
        bomberInput.Player.YawControl.performed -= OnYawPerformed;
        bomberInput.Player.YawControl.canceled -= OnYawCancelled;
        bomberInput.Player.ThrottleControl.performed -= OnThrottlePerformed;
        bomberInput.Player.ThrottleControl.canceled -= OnThrottleCancelled;
        bomberInput.Player.BombRelease.performed -= OnBombDropPerformed;
        bomberInput.Player.BombRelease.canceled -= OnBombDropCancelled;
    }

    private float massCompensation {
        get {
            return (rb.mass / 10f) * bomberResponsiveness;        
        }
    }

    // Update is called once per frame
    private void Update() {
        BomberInputs();
        UpdateHUD();

        propeller.Rotate(Vector3.forward * throttle * 0.1f);
        engineSound.volume = throttle * 0.01f * propVolume;
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * massCompensation);
        rb.AddTorque(transform.right * pitch * massCompensation);
        rb.AddTorque(-transform.forward * roll * massCompensation);

        rb.AddForce(rb.transform.up * rb.velocity.magnitude * liftForce);
    }

    private void UpdateHUD() {
        hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed " + ((rb.velocity.magnitude * 3.6f)/1.609f).ToString("F0") + "mph\n";
        hud.text += "Altitude " + transform.position.y.ToString("F0") + "m\n";
        if (bombReloading) {
            hud.text += "Bombs " + "reloading\n";
        }
        else {
            hud.text += "Bombs " + bombNum.ToString("F0") + "\n";
        }
        hud.text += "Toast Hits " + score.ToString("F0") + "\n";
    }

    private void BomberInputs() {
        //Fetch rotational values
        roll = movementVector.x;
        pitch = movementVector.y;
        yaw = movementYaw;

        //Throttle handling
        if (throttleInp > 0.0f) {
            throttle += throttleAccel;
        }
        else if (throttleInp < 0.0f) {
            throttle -= throttleAccel;
        }
        throttle = Mathf.Clamp(throttle, 0f, 100f);

        //Weapon handling
        if (bombRelease > 0.0f && bombNum > 0 && bombReloading == false) {
            GameObject temp;
            foreach (Transform bombTrans in bombPositions) {
                temp = bombTrans.GetChild(0).gameObject;
                temp.GetComponent<Bomb>().ArmBomb();
                temp.GetComponent<Rigidbody>().velocity = rb.velocity;
                temp.transform.parent = null;
            }
            bombNum = 0;
            bombReloading = true;
            StartCoroutine(ReloadBombs());
        }
    }

    IEnumerator ReloadBombs() {
        yield return new WaitForSeconds(bombReloadTime);
        bombReloading = false;
        bombNum = 2;
        GameObject temp;
        for (int i = 0; i < bombPositions.Length; i++) {
            temp = Instantiate(bombPrefab, bombPositions[i].position, bombPrefab.transform.rotation);
            temp.transform.parent = bombPositions[i];
            temp.GetComponent<Bomb>().player = this;
        }
    }

    public void IncrementScore(int val) {
        score += val;
    }

    //Input handling
    private void OnMovementPerformed(InputAction.CallbackContext value) {
        movementVector = value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value) {
        movementVector = Vector2.zero;
    }
    private void OnYawPerformed(InputAction.CallbackContext value) {
        movementYaw = value.ReadValue<float>();
    }
    private void OnYawCancelled(InputAction.CallbackContext value) {
        movementYaw = 0.0f;
    }
    private void OnThrottlePerformed(InputAction.CallbackContext value) {
        throttleInp = value.ReadValue<float>();
    }
    private void OnThrottleCancelled(InputAction.CallbackContext value) {
        throttleInp = 0.0f;
    }
    private void OnBombDropPerformed(InputAction.CallbackContext value) {
        bombRelease = value.ReadValue<float>(); ;
    }
    private void OnBombDropCancelled(InputAction.CallbackContext value) {
        bombRelease = 0.0f;
    }
    private void OnGunsFiredPeformed(InputAction.CallbackContext value) {
        fireGuns = value.ReadValue<float>(); ;
    }
    private void OnGunsFiredCancelled(InputAction.CallbackContext value) {
        fireGuns = 0.0f;
    }

    //Debug Gizmos
    private void OnDrawGizmos() {

    }

}
