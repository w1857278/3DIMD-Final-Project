using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer cubeRenderer;
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LeftClickInteraction() {
        cubeRenderer.material.color = Color.green; 
    }
}
