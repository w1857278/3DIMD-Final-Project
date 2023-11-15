using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    Rigidbody rb; 
    public Transform playerBody;
    float verticalLookRotation = 0f;
    public float mouseSensitivity = 1000f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + transform.TransformDirection(movement));
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalLookRotation -= mouseY;

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Click");
            Ray leftClickInteractionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(leftClickInteractionRay, out hit)) {
                if (hit.collider != null && Physics.Raycast(leftClickInteractionRay, out hit)) {
                    Debug.Log("Ray Origin Position: " + leftClickInteractionRay.origin);
                    if (hit.collider == GetComponent<BoxCollider>()){
                        Debug.Log("Object hit: " + hit.collider.gameObject.tag);
                    }
                }
            }
            Debug.DrawRay(leftClickInteractionRay.origin, leftClickInteractionRay.direction * 10f, Color.red, 1f);
             
        }
    }

}
