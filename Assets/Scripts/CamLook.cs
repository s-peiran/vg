using UnityEngine;


public class CamLook : MonoBehaviour {
    /*
     * Controls rotation of viewport, simulates first-person head rotation
     */

    public Transform orientation;

    public bool hasStarted = false;
    public bool canRotate = false;


    [SerializeField] float sensX = 0.3f;
    [SerializeField] float sensY = 0.2f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    void Start() {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update() {
        if (hasStarted) {
            if (Input.GetMouseButtonDown(0)) {
            canRotate = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            canRotate = false;
        }

        UpdateRotation();
        }
    }


    void UpdateRotation()
    {
        if (canRotate) {
            Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
 
            currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
    
            cameraCap -= currentMouseDelta.y * sensY;
            cameraCap = Mathf.Clamp(cameraCap, -70f, 70f);
    
            Camera.main.transform.localEulerAngles = Vector3.right * cameraCap;

            orientation.Rotate(Vector3.up * currentMouseDelta.x * sensX);
        }
        
    }
}
