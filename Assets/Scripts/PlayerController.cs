using System;
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
    private float xLook = 0f;


    
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
        xLook -= mouseY;
        // xLook.Math.Clamp();

        Camera.main.transform.localRotation = Quaternion.Euler(xLook, 0, 0);

        Ray leftClickInteractionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // if (Physics.Raycast(leftClickInteractionRay, out hit)) {
        //     if (hit.collider != null && Physics.Raycast(leftClickInteractionRay, out hit)) {
        //         Debug.Log("Ray Origin Position: " + leftClickInteractionRay.origin);
        //         MonoBehaviour hitObject = hit.collider.gameObject.GetComponent<MonoBehaviour>();;
                
        //         if (hitObject != null){
        //             Type objectType = hitObject.GetType();
        //             Debug.Log("Object Has Interaction Function");
                    
        //         }
        //         else {
        //             Debug.Log("Object does not have interaction function");
        //         }
        //     }
        // }
        // if (Input.GetMouseButtonDown(0)) {
        //     Debug.Log("Click");
            
            
                         
        // }
    }

}
