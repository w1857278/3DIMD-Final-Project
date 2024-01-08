using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftLog : LookObject
{
    public Slider verticalSlider;
    public Vector3 startPosition;
public override void Start() {
        base.Start();
        startPosition = transform.position;
    }
    public override void Update() {
        base.Update();
        
    }
    public override void InteractingUpdate() {
        base.InteractingUpdate();
        float slideValue = verticalSlider.value;
        transform.rotation = Quaternion.Euler(slideValue * 90, -90 , 0);
        transform.position = startPosition + new Vector3(slideValue * -10, slideValue * 10, 0);
        if(slideValue == 1) BackOut();
    }
    public override void LeftClickInteraction() {

        base.LeftClickInteraction();
        verticalSlider.gameObject.SetActive(true);

    }
    public override void BackOut() {
        // Removes minigame elements when the player backs out of the minigame
        base.BackOut();
        verticalSlider.gameObject.SetActive(false);
    }
}
