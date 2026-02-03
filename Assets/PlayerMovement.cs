using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameObject camObj;
    private Rigidbody rb;
    [Range(0.2f,5f)]
    public float xTurnSpeed, yTurnSpeed;
    public float moveSpeed;
    private float rotX = 0, rotY = 0;
    public int runMult;
    private int currentRunMult;
    private bool running;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camObj = GetComponentInChildren<Camera>().gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        running = Input.GetKey(KeyCode.LeftShift);

        if (running) { currentRunMult = runMult; }
        else         { currentRunMult = 1; }

        rotX += Input.GetAxis("Mouse X") * xTurnSpeed;
        rotX %= 360;

        rotY -= Input.GetAxisRaw("Mouse Y") * yTurnSpeed;
        rotY = Mathf.Clamp(rotY, -80,80);

        transform.eulerAngles = Vector3.up * rotX;
        camObj.transform.eulerAngles = new Vector3(rotY, camObj.transform.eulerAngles.y, camObj.transform.eulerAngles.z);

        Vector3 movDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical")).normalized;
        movDir = (transform.forward * movDir.z) + (transform.right * movDir.x);
        transform.position += movDir * Time.deltaTime * moveSpeed * currentRunMult;
    }
}
