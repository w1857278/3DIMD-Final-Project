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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        playerScript = player.GetComponent<PlayerController>();
        Debug.Log(transform);
        foreach(Transform child in transform) {
            Debug.Log("Child");
            if(child.tag == "CamPosition") camChild = child;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(interacting && Input.GetMouseButtonDown(1)) {
            playerScript.ReturnCamera();
        }
    }
    public void LeftClickInteraction() {
        interacting = true;
        if(camChild != null) {
            playerScript.CameraShift(camChild.transform.position, transform.position);
        }
        else {
            Debug.Log("Child object does not exist");
        }
        
    }
}
