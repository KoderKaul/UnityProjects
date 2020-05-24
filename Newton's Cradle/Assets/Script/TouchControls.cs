using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    bool dragging = false;
    public bool speedchange = false;
    public Rigidbody b1;


    private void OnMouseDrag()
    {
        dragging = true;
        speedchange = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
    private void FixedUpdate()
    {
        if (dragging)
        {
            float x =  500f * Time.fixedDeltaTime;
            b1.AddForce(Vector3.back*x);
            Debug.Log(speedchange+" rForce lagao");
        }
    }


   
}
