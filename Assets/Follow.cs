using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{

    public CollisionCheck collisionScript;
    public float rotateSpeed = 5f;

    private Transform player;

    private Rigidbody rb;

    
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Codey").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        if (collisionScript.canFollow)
        {
            
                Debug.Log("e");
                Vector3 direction = player.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

                transform.position += speed * direction;
            
        }
        //rb.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.tag == "Player")
         {
             Vector3 direction = player.position - transform.position;
             rb.AddForce(-direction * 1000, ForceMode.Impulse);
         }

     }
    */
  

}
