using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public List<Item> inventory = new List<Item>();
    public float moveSpeed = 5f; 
    Rigidbody rb; 
    public Transform playerBody;
    float verticalLookRotation = 0f;
    public float mouseSensitivity = 1000f;
    private float xLook = 0f;

    public int coins = 0;

    private bool cameraControlEnabled = true;
    private bool movementEnabled = true;
    Transform camChild;
    public UI ui;
    public Image interactPrompt;
    public Image negativeInteractPrompt;
    
    public Image cursorImage;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true;
        Cursor.visible = false;
        cursorImage.gameObject.SetActive(false);
        
    }

    void Update()
    {

        //Cursor Image replacement
        Vector2 mousePosition = Input.mousePosition;
        cursorImage.transform.position = mousePosition;

        

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
        interactPrompt.gameObject.SetActive(false);
        negativeInteractPrompt.gameObject.SetActive(false);
        if (Physics.Raycast(leftClickInteractionRay, out hit, 10f)) {
            if (hit.collider != null) {
                MonoBehaviour hitObject = hit.collider.gameObject.GetComponent<MonoBehaviour>();
                //Check if hit object has LeftClickInteract Function
                if (hitObject != null) {
                    Type objectType = hitObject.GetType();
                    System.Reflection.MethodInfo methodInfo = objectType.GetMethod("LeftClickInteraction");
                    //Invoke the method when LMB is pressed
                    if (methodInfo != null) {
                        interactPrompt.gameObject.SetActive(true);
                        if (Input.GetMouseButtonDown(0)) {
                            methodInfo.Invoke(hitObject, null);
                        }
                        
                    }
                }
            }
        }
    }

    public void AddCoin() {
        coins++;
    }

    public void LockCamera() {
        Cursor.lockState = CursorLockMode.Confined;
        cameraControlEnabled = false;
        movementEnabled = false;
        cursorImage.gameObject.SetActive(true);
    }
    public void UnlockCamera() {
        Cursor.lockState = CursorLockMode.Locked;
        cameraControlEnabled = true;
        movementEnabled = true;
        cursorImage.gameObject.SetActive(false);
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
