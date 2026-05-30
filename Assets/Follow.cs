using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    public float rotateSpeed = 5f;

    private Transform player;

    private Rigidbody rb;

    private float distance;
    
    public float speed;

    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Codey").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = true;
    }
    void Update()
    {     
         Debug.Log("e");
         Vector3 direction = player.position - transform.position;

        Debug.Log(direction.magnitude);
        
        if (direction.magnitude <= chaseDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            transform.position += speed * direction.normalized;
            rb.isKinematic = false;

        }
        if (direction.magnitude > chaseDistance)
        {
            rb.isKinematic = true;
        }



    }
        //rb.AddForce(direction * speed, ForceMode.VelocityChange);
   

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
