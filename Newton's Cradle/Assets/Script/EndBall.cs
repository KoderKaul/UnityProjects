
using UnityEngine;

public class EndBall : MonoBehaviour
{
    public Rigidbody rb1;
    public Rigidbody rb2;
    public Velocity local;
    
    private void OnCollisionEnter(Collision collision)
    {

        
            //speed2 = 0;
            rb1.isKinematic = false;
            rb2.isKinematic = true;
            rb1.velocity = -local.speed;
        
        Debug.Log(collision.collider.name+" " + local.speed);
    }
    
}
