using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public List<Item> inventory = new List<Item>();
    public float moveSpeed = 5f; 
    Rigidbody rb; 
    public Transform playerBody;
    float verticalLookRotation = 0f;
    public float mouseSensitivity = 1000f;
    private float xLook = 0f;

    private bool cameraControlEnabled = true;
    private bool movementEnabled = true;
    Transform camChild;
    public UI ui;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true;

        
    }

    void Update()
    {

        //Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        if(movementEnabled) {
            rb.MovePosition(rb.position + transform.TransformDirection(movement));
        }

        //MouseLook
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalLookRotation -= mouseY;
        xLook -= mouseY;
        xLook = Mathf.Clamp(xLook, -70f, 70f);

        if(cameraControlEnabled) {
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(xLook, 0, 0);
        }
        
        
        // Create Raycast
        Ray leftClickInteractionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        // Check to see if ray has hit something
        if (Physics.Raycast(leftClickInteractionRay, out hit, 10f)) {
            if (hit.collider != null) {
                MonoBehaviour hitObject = hit.collider.gameObject.GetComponent<MonoBehaviour>();
                //Check if hit object has LeftClickInteract Function
                if (hitObject != null) {
                    Type objectType = hitObject.GetType();
                    System.Reflection.MethodInfo methodInfo = objectType.GetMethod("LeftClickInteraction");
                    //Invoke the method when LMB is pressed
                    if (methodInfo != null) {

                        if (Input.GetMouseButtonDown(0)) {
                            methodInfo.Invoke(hitObject, null);
                        }
                        
                    }
                }
            }
        }
    }

    public void LockCamera() {
        Cursor.lockState = CursorLockMode.Confined;
        cameraControlEnabled = false;
        movementEnabled = false;
    }
    public void UnlockCamera() {
        Cursor.lockState = CursorLockMode.Locked;
        cameraControlEnabled = true;
        movementEnabled = true;
    }

    public void CameraShift(Vector3 cameraLocation, Vector3 cameraFocus) {
        Camera.main.transform.position =  cameraLocation;
        Camera.main.transform.rotation = Quaternion.LookRotation(cameraFocus - transform.position);
        LockCamera();
    }
    public void ReturnCamera() {
        
        
        foreach(Transform child in transform) {
            if(child.tag == "CamPosition") camChild = child;
        };
        UnlockCamera();
        Camera.main.transform.position = camChild.transform.position;
    }
    public void AddItem(Item item) {
        inventory.Add(item);
        ui.UpdateUI();
    }
    public void CheckHasItem(int itemID) {

    }
}
