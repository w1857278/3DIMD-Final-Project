using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 sc;
    private Vector3 offsey;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
   public void OnMouseDown()
    {
        sc = Camera.main.WorldToScreenPoint(transform.position);
        offsey = sc - Input.mousePosition;
    }
   public  void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + offsey);
    }
}

