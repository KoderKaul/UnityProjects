
using UnityEngine;

public class Velocity : MonoBehaviour

{
    public Rigidbody rb1;
    public Rigidbody rb2;
    public Vector3 speed;
    public TouchControls tc;
    
    private void OnCollisionEnter(Collision collision)
    {

        //speed = 0;
        if (tc.speedchange) {
            tc.speedchange = false;
            speed = new Vector3(0, 0, collision.relativeVelocity.magnitude);
        }
        
        rb2.isKinematic = false;
        rb1.isKinematic = true;
        rb2.velocity = speed;
        
        
        Debug.Log(collision.collider.name+" Speed " + collision.relativeVelocity.magnitude);
    }
   
}
