using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /*
     * Controls movement of the player
     */

    public bool canWalk;
    
    [SerializeField] private float normalWalkingSpeed = 1.6f;
    [SerializeField] private float walkingSpeed;

    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDir;
    private Rigidbody rb;

    // private int paintingLayer = 0;
    // private bool isSlowed = false;
    // private bool isSpeedNormal = true;
    // private Coroutine changeSpeed;
    // private float distFromPainting = 1.6f;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        walkingSpeed = normalWalkingSpeed;
        canWalk = true;
    }

    // Start is called before the first frame update
    void Start() {
        rb.freezeRotation = true;

        transform.position = new Vector3(-7f, 0.94f, 14.5f);
        transform.rotation = Quaternion.Euler(0f, 157f, 0f);
    }


    private void FixedUpdate() {
        UpdateTranslation();
    }

    // Update is called once per frame
    void Update() {
        if (canWalk) {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            // UpdateSpeed();
            SpeedLimit();
        }
        
    }

    private void UpdateTranslation() {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDir.normalized * walkingSpeed * 10f, ForceMode.Force);
    }

    private void SpeedLimit() {
        Vector3 v = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (v.magnitude > normalWalkingSpeed) {
            Vector3 maxV = v.normalized * normalWalkingSpeed;
            rb.velocity = new Vector3(maxV.x, 0f, maxV.z);
        }
    }

    // public IEnumerator DecreaseSpeed() {
    //     Debug.Log("slowing down");
    //     isSlowed = true;
    //     while (walkingSpeed > slowWalkingSpeed) {
    //         walkingSpeed -= 0.01f;
    //         yield return new WaitForSeconds(0.01f);
    //     }
    //     walkingSpeed = slowWalkingSpeed;
    //     rb.drag = 11f;
    //     isSpeedNormal = false;
    // }

    // public IEnumerator NormalSpeed() {
    //     Debug.Log("speeding up");
    //     isSpeedNormal = true;
    //     while (walkingSpeed < normalWalkingSpeed) {
    //         walkingSpeed += 0.01f;
    //         yield return new WaitForSeconds(0.01f);
    //     }
    //     walkingSpeed = normalWalkingSpeed;
    //     rb.drag = 5f;
    //     isSlowed = false;
    // }

    // private void UpdateSpeed() {
    //     //bool isAroundPainting = false;
    //     // Vector3 paintingPos = new Vector3();

    //     Collider[] colliders = Physics.OverlapSphere(transform.position, distFromPainting);
    //     foreach (Collider c in colliders) {
    //         if (c.gameObject.layer == paintingLayer) {
    //             // isAroundPainting = true;
    //             paintingPos = c.transform.position;
    //             break;
    //         }
    //     }   

    //     // if (isAroundPainting) {
    //     //     if (!isSlowed) {
    //     //         if (changeSpeed != null) {
    //     //             StopCoroutine(changeSpeed);
    //     //         }
    //     //         changeSpeed = StartCoroutine(DecreaseSpeed());
    //     //     }
    //     // } else {
    //     //     if (!isSpeedNormal) {
    //     //         if (changeSpeed != null) {
    //     //             StopCoroutine(changeSpeed);
    //     //         }
    //     //         changeSpeed = StartCoroutine(NormalSpeed());
    //     //     }
    //     // }
    // }
}