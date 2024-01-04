using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequireItemCube : MonoBehaviour
{

    //Ensure these two variables exist when an object requires an item to be interacted with
    public bool requiresItem = true;
    public int itemRequired = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftClickInteraction() {
        Debug.Log("Has Item");
    }
}
