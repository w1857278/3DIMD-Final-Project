using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{
    bool interacting = false;
    
    Vector3 camPosition;
    PlayerController playerScript;
    Transform camChild;
    
    
    // Start is called before the first frame update
    public virtual void  Start()
    {
        //Assign variables for player object and player's camera object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        playerScript = player.GetComponent<PlayerController>();
        foreach(Transform child in transform) {
            if(child.tag == "CamPosition") camChild = child;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Check if player is interacting with a Look Object and run the child function
        if(interacting) {
            InteractingUpdate();
        }
        
    }
    public virtual void BackOut() {
        //Return the player camera to player body and allow mouse look
        playerScript.ReturnCamera();
        interacting = false;
    }
    public virtual void InteractingUpdate() {
        // Update method while the player is in "Minigame mode"
        // Prevents interaction prompts from appearing and will return control to the player once they back out
        playerScript.interactPrompt.gameObject.SetActive(false);
        playerScript.negativeInteractPrompt.gameObject.SetActive(false);
        if(Input.GetMouseButtonDown(1)) {
            BackOut();
        }
    }
    public virtual void LeftClickInteraction() {
        // Starts "Minigame Mode" when player interacts with a look object
        interacting = true;
        if(camChild != null) {
            playerScript.CameraShift(camChild.transform.position, transform.position);
        }
        else {
            Debug.Log("Camera object does not exist");
        }
        
    }
}
